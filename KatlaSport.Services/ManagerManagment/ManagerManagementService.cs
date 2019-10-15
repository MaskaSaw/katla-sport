using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ManagerCatalogue;
using Microsoft.WindowsAzure.Storage.Blob;

namespace KatlaSport.Services.ManagerManagement
{
    internal class ManagerManagmentService : IManagerService
    {
        IManagerContext _context;

        public ManagerManagmentService(IManagerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ManagerRequest>> GetManagersAsync()
        {
            var dbManagers = await _context.Managers.OrderBy(m => m.Id).ToListAsync();
            var managers = dbManagers.Select(m => Mapper.Map<Manager, ManagerRequest>(m)).ToList();

            return managers;
        }

        public async Task<ManagerRequest> GetManagerAsync(int managerId)
        {
            var dbManagers = await _context.Managers.Where(m => m.Id == managerId).ToArrayAsync();
            if (dbManagers.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var managers = Mapper.Map<Manager, ManagerRequest>(dbManagers[0]);
            return managers;
        }

        public async Task<Manager> CreateManagerAsync(ManagerRequest managerRequest, CloudBlobContainer blobContainer, HttpPostedFile file)
        {
            var dbManager = await _context.Managers.Where(m => (m.Surname == managerRequest.Surname && m.Name == managerRequest.Name)).ToArrayAsync();
            if (dbManager.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var fileName = GetRandomBlobName(file.FileName);
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(fileName);
            using (var fileStream = file.InputStream)
            {
                await blob.UploadFromStreamAsync(fileStream);
            }

            managerRequest.Photo = blob.Uri.ToString();

            var manager = Mapper.Map<ManagerRequest, Manager>(managerRequest);
            _context.Managers.Add(manager);

            await _context.SaveChangesAsync();

            return manager;
        }

        public async Task<Manager> UpdateManagerAsync(int managerId, ManagerRequest updateManager, CloudBlobContainer blobContainer, HttpPostedFile file)
        {
            var dbManagers = await _context.Managers.Where(m => m.Name == updateManager.Name && m.Id != managerId).ToArrayAsync();
            if (dbManagers.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbManagers = _context.Managers.Where(p => p.Id == managerId).ToArray();
            if (dbManagers.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbmanager = dbManagers[0];

            var fileName = GetRandomBlobName(file.FileName);
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(fileName);
            using (var fileStream = file.InputStream)
            {
                await blob.UploadFromStreamAsync(fileStream);
            }

            string filename = Path.GetFileName(dbmanager.Photo);

            var blobDelete = blobContainer.GetBlockBlobReference(filename);
            await blobDelete.DeleteIfExistsAsync();

            dbmanager.Photo = blob.Uri.ToString();
            dbmanager.Name = updateManager.Name;
            dbmanager.Surname = updateManager.Surname;
            dbmanager.Age = updateManager.Age;
            dbmanager.ChiefId = updateManager.ChiefId;
            await _context.SaveChangesAsync();

            return dbmanager;
        }

        public async Task DeleteManagerAsync(int managerId, CloudBlobContainer blobContainer)
        {
            var dbManagers = await _context.Managers.Where(m => m.Id == managerId).ToArrayAsync();
            if (dbManagers.Length == 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            string filename = Path.GetFileName(dbManagers[0].Photo);

            var blobDelete = blobContainer.GetBlockBlobReference(filename);
            await blobDelete.DeleteIfExistsAsync();

            var dbChildren = await _context.Managers.Where(m => m.ChiefId == managerId).ToArrayAsync();

            foreach (Manager a in dbChildren)
            {
                a.ChiefId = dbManagers[0].ChiefId;
            }

            _context.Managers.Remove(dbManagers[0]);
            await _context.SaveChangesAsync();
        }

        private string GetRandomBlobName(string filename)
        {
            string ext = Path.GetExtension(filename);
            return string.Format("{0:10}_{1}{2}", DateTime.Now.Ticks, Guid.NewGuid(), ext);
        }
    }
}

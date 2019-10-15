using KatlaSport.DataAccess.ManagerCatalogue;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace KatlaSport.Services.ManagerManagement
{
    public interface IManagerService
    {
        Task<List<ManagerRequest>> GetManagersAsync();

        Task<ManagerRequest> GetManagerAsync(int managerId);

        Task<Manager> CreateManagerAsync(ManagerRequest manager, CloudBlobContainer blobContainer, HttpPostedFile file);

        Task<Manager> UpdateManagerAsync(int managerId, ManagerRequest updateManager, CloudBlobContainer blobContainer, HttpPostedFile file);

        Task DeleteManagerAsync(int managerId, CloudBlobContainer blobContainer);
    }
}

using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ClientCatalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatlaSport.Services.ClientManagement
{
    internal class ClientManagementService : IClientService
    {
        private IClientContext _context;

        public ClientManagementService(IClientContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            var dbClients = await _context.Clients.OrderBy(c => c.Id).ToListAsync();

            return dbClients;
        }

        public async Task<Client> GetClientAsync(int clientId)
        {
            var dbClients = await _context.Clients.Where(c => c.Id == clientId).ToArrayAsync();
            if (dbClients.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return dbClients[0];
        }

        public async Task<Client> CreateClientAsync(ClientRequest clientRequest)
        {
            var dbClient = await _context.Clients.Where(c => (c.Name == clientRequest.Name && c.City == clientRequest.Name)).ToArrayAsync();
            if (dbClient.Length > 0)
            {
                throw new RequestedResourceHasConflictException("city");
            }

            var client = Mapper.Map<ClientRequest, Client>(clientRequest);
            _context.Clients.Add(client);

            await _context.SaveChangesAsync();

            return client;
        }

        public async Task<Client> UpdateClientAsync(int clientId, ClientRequest clientRequest)
        {
            var dbClients = await _context.Clients.Where(c => c.Name == clientRequest.Name && c.Id != clientId).ToArrayAsync();
            if (dbClients.Length > 0)
            {
                throw new RequestedResourceHasConflictException("name");
            }

            dbClients = _context.Clients.Where(c => c.Id == clientId).ToArray();
            if (dbClients.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbClient = dbClients[0];

            dbClient.Name = clientRequest.Name;
            dbClient.Address = clientRequest.Address;
            dbClient.City = clientRequest.City;
            await _context.SaveChangesAsync();

            return dbClient;
        }

        public async Task DeleteClientAsync(int clientId)
        {
            var dbClients = await _context.Clients.Where(c => c.Id == clientId).ToArrayAsync();
            if (dbClients.Length == 0)
            {
                throw new RequestedResourceHasConflictException("Id");
            }

            _context.Clients.Remove(dbClients[0]);
            await _context.SaveChangesAsync();
        }
    }
}

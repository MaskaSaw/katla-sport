using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KatlaSport.DataAccess.ClientCatalogue;
using KatlaSport.Services.ClientManagement;

namespace KatlaSport.Services.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IClientService _clientService;

        public ClientRepository(IClientService clientService)
        {
            _clientService = clientService ?? throw new ArgumentNullException();
        }

        public async Task<List<Client>> GetItems()
        {
            return await _clientService.GetClientsAsync();
        }

        public async Task<Client> GetItem(int id)
        {
            return await _clientService.GetClientAsync(id);
        }

        public async Task<Client> Create(ClientRequest createRequest)
        {
            return await _clientService.CreateClientAsync(createRequest);
        }

        public async Task<Client> Update(int id, ClientRequest updateRequest)
        {
            return await _clientService.UpdateClientAsync(id, updateRequest);
        }

        public async Task Delete(int id)
        {
            await _clientService.DeleteClientAsync(id);
        }
    }
}

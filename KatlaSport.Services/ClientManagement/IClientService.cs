using KatlaSport.DataAccess.ClientCatalogue;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ClientManagment
{
    public interface IClientService
    {
        Task<List<Client>> GetClientsAsync();

        Task<Client> GetClientAsync(int clientId);

        Task<Client> CreateClientAsync(ClientRequest client);

        Task<Client> UpdateClientAsync(int clientId, ClientRequest updateClient);

        Task DeleteClientAsync(int clientId);
    }
}

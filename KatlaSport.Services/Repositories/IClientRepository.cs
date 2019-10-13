using System.Collections.Generic;
using System.Threading.Tasks;
using KatlaSport.DataAccess.ClientCatalogue;
using KatlaSport.Services.ClientManagement;

namespace KatlaSport.Services.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetItems();

        Task<Client> GetItem(int id);

        Task<Client> Create(ClientRequest createRequest);

        Task<Client> Update(int id, ClientRequest updateRequest);

        Task Delete(int id);
    }
}



namespace KatlaSport.DataAccess.ClientCatalogue
{
    internal sealed class ClientContext : DomainContextBase<ApplicationDbContext>, IClientContext
    {
        public ClientContext(ApplicationDbContext dbContext)
          : base(dbContext)
        {
        }

        public IEntitySet<Client> Clients => GetDbSet<Client>();
    }
}

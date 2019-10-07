namespace KatlaSport.DataAccess.ManagerCatalogue
{
    internal sealed class ManagerContext : DomainContextBase<ApplicationDbContext>, IManagerContext
    {
        public ManagerContext(ApplicationDbContext dbContext)
          : base(dbContext)
        {
        }

        public IEntitySet<Manager> Managers => GetDbSet<Manager>();
    }
}

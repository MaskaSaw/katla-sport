namespace KatlaSport.DataAccess.OrderCatalogue
{
    internal sealed class OrderContext : DomainContextBase<ApplicationDbContext>, IOrderContext
    {
        public OrderContext(ApplicationDbContext dbContext)
           : base(dbContext)
        {
        }

        public IEntitySet<Order> Orders => GetDbSet<Order>();
    }
}

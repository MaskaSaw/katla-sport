namespace KatlaSport.DataAccess.OrderCatalogue
{
    public interface IOrderContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Order"/> entities.
        /// </summary>
        IEntitySet<Order> Orders { get; }
    }
}

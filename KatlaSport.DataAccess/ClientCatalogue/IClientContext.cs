namespace KatlaSport.DataAccess.ClientCatalogue
{
    public interface IClientContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Client"/> entities.
        /// </summary>
        IEntitySet<Client> Clients { get; }
    }
}

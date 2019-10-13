namespace KatlaSport.DataAccess.ManagerCatalogue
{
    /// <summary>
    /// Represents a context for accountant domain.
    /// </summary>
    public interface IManagerContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Manager"/> entities.
        /// </summary>
        IEntitySet<Manager> Managers { get; }
    }
}

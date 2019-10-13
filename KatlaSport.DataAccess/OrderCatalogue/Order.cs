using KatlaSport.DataAccess.ClientCatalogue;
using KatlaSport.DataAccess.ManagerCatalogue;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    public class Order
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a product ID.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets a client.
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// Gets or sets a manager ID.
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// Gets or sets a manager
        /// </summary>
        public virtual Manager Manager { get; set; }
    }
}


namespace KatlaSport.Services.OrderManagement
{
    public class OrderRequest
    {
        /// <summary>
        /// Gets or sets a product store item ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a product ID.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets a location ID.
        /// </summary>
        public int ManagerId { get; set; }
    }
}

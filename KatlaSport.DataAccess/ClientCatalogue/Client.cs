using System.Collections.Generic;
using KatlaSport.DataAccess.OrderCatalogue;

namespace KatlaSport.DataAccess.ClientCatalogue
{
    public class Client
    {
        /// <summary>
        /// Gets or sets a Client ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a Client Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a Client Address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a Client city.
        /// </summary>
        public string City { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

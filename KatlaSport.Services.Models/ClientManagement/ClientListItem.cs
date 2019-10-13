namespace KatlaSport.Services.ClientManagement
{
    public class ClientListItem
    {
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
    }
}

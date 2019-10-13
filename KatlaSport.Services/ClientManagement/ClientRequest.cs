﻿namespace KatlaSport.Services.ClientManagement
{
    public class ClientRequest
    {
        /// <summary>
        /// Gets or sets a company ID.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets a company Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a company Address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a company city.
        /// </summary>
        public string City { get; set; }
    }
}
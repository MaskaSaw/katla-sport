using System.Collections.Generic;
using KatlaSport.DataAccess.OrderCatalogue;

namespace KatlaSport.DataAccess.ManagerCatalogue
{
    public class Manager
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a manager Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a Manager Surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets a Manager Age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets a Manager ChiefId.
        /// </summary>
        public int? ChiefId { get; set; }

        public string Photo { get; set; }

        public virtual Manager Chief { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

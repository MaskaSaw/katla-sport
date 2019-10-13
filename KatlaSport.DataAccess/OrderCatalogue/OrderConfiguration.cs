using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    internal sealed class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("order");
            HasKey(i => i.Id);
            HasRequired(i => i.Manager).WithMany(i => i.Orders).HasForeignKey(i => i.ManagerId);
            HasRequired(i => i.Client).WithMany(i => i.Orders).HasForeignKey(i => i.ClientId);
            Property(i => i.Id).HasColumnName("order_id");
            Property(i => i.ClientId).HasColumnName("order_client_id");
            Property(i => i.ManagerId).HasColumnName("order_manager_id");
        }
    }
}

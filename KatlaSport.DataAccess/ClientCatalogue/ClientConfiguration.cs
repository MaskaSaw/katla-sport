using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ClientCatalogue
{
    internal sealed class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            ToTable("clients");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("client_id");
            Property(i => i.Name).HasColumnName("client_name");
            Property(i => i.Address).HasColumnName("client_address");
            Property(i => i.City).HasColumnName("client_city");
        }
    }
}

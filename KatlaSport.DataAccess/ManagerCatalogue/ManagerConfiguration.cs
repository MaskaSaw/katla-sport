using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ManagerCatalogue
{
    internal sealed class ManagerConfiguration : EntityTypeConfiguration<Manager>
    {
        public ManagerConfiguration()
        {
            ToTable("managers");
            HasKey(i => i.Id);
            HasRequired(i => i.Chief).WithMany(i => i.Managers).HasForeignKey(i => i.ChiefId);
            Property(i => i.Id).HasColumnName("manager_id");
            Property(i => i.Name).HasColumnName("manager_name");
            Property(i => i.Surname).HasColumnName("manager_surname");
            Property(i => i.Age).HasColumnName("manager_age");
            Property(i => i.ChiefId).HasColumnName("manager_chiefid");
            Property(i => i.Photo).HasColumnName("manager_photo");
        }
    }
}

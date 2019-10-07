namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.customer_records", "LastUpdated");
            DropColumn("dbo.customer_records", "LastUpdatedBy");
            DropColumn("dbo.customer_records", "IsDeleted");
        }

        public override void Down()
        {
            AddColumn("dbo.customer_records", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.customer_records", "LastUpdatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.customer_records", "LastUpdated", c => c.DateTime(nullable: false));
        }
    }
}

namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TestMG : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.order", "order_client_id", "dbo.clients");
            DropForeignKey("dbo.managers", "manager_chiefid", "dbo.managers");
            DropForeignKey("dbo.order", "order_manager_id", "dbo.managers");
            DropIndex("dbo.order", new[] { "order_client_id" });
            DropIndex("dbo.order", new[] { "order_manager_id" });
            DropIndex("dbo.managers", new[] { "manager_chiefid" });
            DropTable("dbo.order");
            DropTable("dbo.clients");
            DropTable("dbo.managers");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.managers",
                c => new
                    {
                        manager_id = c.Int(nullable: false, identity: true),
                        manager_name = c.String(),
                        manager_surname = c.String(),
                        manager_age = c.Int(nullable: false),
                        manager_chiefid = c.Int(nullable: false),
                        manager_photo = c.String(),
                    })
                .PrimaryKey(t => t.manager_id);

            CreateTable(
                "dbo.clients",
                c => new
                    {
                        client_id = c.Int(nullable: false, identity: true),
                        client_name = c.String(),
                        client_address = c.String(),
                        client_city = c.String(),
                    })
                .PrimaryKey(t => t.client_id);

            CreateTable(
                "dbo.order",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        order_client_id = c.Int(nullable: false),
                        order_manager_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_id);

            CreateIndex("dbo.managers", "manager_chiefid");
            CreateIndex("dbo.order", "order_manager_id");
            CreateIndex("dbo.order", "order_client_id");
            AddForeignKey("dbo.order", "order_manager_id", "dbo.managers", "manager_id", cascadeDelete: true);
            AddForeignKey("dbo.managers", "manager_chiefid", "dbo.managers", "manager_id");
            AddForeignKey("dbo.order", "order_client_id", "dbo.clients", "client_id", cascadeDelete: true);
        }
    }
}

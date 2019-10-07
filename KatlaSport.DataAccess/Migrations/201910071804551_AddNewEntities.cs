namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddNewEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.order",
                c => new
                {
                    order_id = c.Int(nullable: false, identity: true),
                    order_client_id = c.Int(nullable: false),
                    order_manager_id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.clients", t => t.order_client_id, cascadeDelete: true)
                .ForeignKey("dbo.managers", t => t.order_manager_id, cascadeDelete: true)
                .Index(t => t.order_client_id)
                .Index(t => t.order_manager_id);

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
                .PrimaryKey(t => t.manager_id)
                .ForeignKey("dbo.managers", t => t.manager_chiefid)
                .Index(t => t.manager_chiefid);
        }

        public override void Down()
        {
            DropForeignKey("dbo.order", "order_manager_id", "dbo.managers");
            DropForeignKey("dbo.managers", "manager_chiefid", "dbo.managers");
            DropForeignKey("dbo.order", "order_client_id", "dbo.clients");
            DropIndex("dbo.managers", new[] { "manager_chiefid" });
            DropIndex("dbo.order", new[] { "order_manager_id" });
            DropIndex("dbo.order", new[] { "order_client_id" });
            DropTable("dbo.managers");
            DropTable("dbo.clients");
            DropTable("dbo.order");
        }
    }
}

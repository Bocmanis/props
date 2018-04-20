namespace props.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init33 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pets", "OwnerId", "dbo.Customers");
            DropIndex("dbo.Pets", new[] { "OwnerId" });
            DropColumn(table: "dbo.Pets", name: "OwnerId");
            AddForeignKey("dbo.Pets", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Pets", new[] { "Customer_Id" });
            AlterColumn("dbo.Pets", "Customer_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Pets", name: "Customer_Id", newName: "OwnerId");
            CreateIndex("dbo.Pets", "OwnerId");
            AddForeignKey("dbo.Pets", "OwnerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}

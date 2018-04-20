namespace props.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPets13wd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pets", "Ownder_Id", "dbo.Customers");
            DropIndex("dbo.Pets", new[] { "Ownder_Id" });
            RenameColumn(table: "dbo.Pets", name: "Ownder_Id", newName: "OwnerId");
            AlterColumn("dbo.Pets", "OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pets", "OwnerId");
            AddForeignKey("dbo.Pets", "OwnerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Pets", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Pets", "OwnerId", "dbo.Customers");
            DropIndex("dbo.Pets", new[] { "OwnerId" });
            AlterColumn("dbo.Pets", "OwnerId", c => c.Int());
            RenameColumn(table: "dbo.Pets", name: "OwnerId", newName: "Ownder_Id");
            CreateIndex("dbo.Pets", "Ownder_Id");
            AddForeignKey("dbo.Pets", "Ownder_Id", "dbo.Customers", "Id");
        }
    }
}

namespace props.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPets1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "FavouritePet_Id", "dbo.Pets");
            DropIndex("dbo.Customers", new[] { "FavouritePet_Id" });
            RenameColumn(table: "dbo.Customers", name: "FavouritePet_Id", newName: "FavouritePetId");
            AlterColumn("dbo.Customers", "FavouritePetId", c => c.Int(nullable: true));
            CreateIndex("dbo.Customers", "FavouritePetId");
            AddForeignKey("dbo.Customers", "FavouritePetId", "dbo.Pets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "FavouritePetId", "dbo.Pets");
            DropIndex("dbo.Customers", new[] { "FavouritePetId" });
            AlterColumn("dbo.Customers", "FavouritePetId", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "FavouritePetId", newName: "FavouritePet_Id");
            CreateIndex("dbo.Customers", "FavouritePet_Id");
            AddForeignKey("dbo.Customers", "FavouritePet_Id", "dbo.Pets", "Id");
        }
    }
}

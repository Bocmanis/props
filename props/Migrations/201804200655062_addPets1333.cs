namespace props.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPets1333 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "FavouritePetId", newName: "FavouritePet_Id");
            RenameIndex(table: "dbo.Customers", name: "IX_FavouritePetId", newName: "IX_FavouritePet_Id");
            DropColumn("dbo.Customers", "Number");
            DropColumn("dbo.Customers", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String());
            AddColumn("dbo.Customers", "Number", c => c.String());
            RenameIndex(table: "dbo.Customers", name: "IX_FavouritePet_Id", newName: "IX_FavouritePetId");
            RenameColumn(table: "dbo.Customers", name: "FavouritePet_Id", newName: "FavouritePetId");
        }
    }
}

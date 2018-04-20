namespace props.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Species = c.String(),
                        Colour = c.String(),
                        FavouritePet = c.Boolean(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Ownder_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Ownder_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Ownder_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.FullProps",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                        PropertyPattern_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyPatterns", t => t.PropertyPattern_Id)
                .Index(t => t.PropertyPattern_Id);
            
            AddColumn("dbo.Customers", "FavouritePet_Id", c => c.Int());
            CreateIndex("dbo.Customers", "FavouritePet_Id");
            AddForeignKey("dbo.Customers", "FavouritePet_Id", "dbo.Pets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FullProps", "PropertyPattern_Id", "dbo.PropertyPatterns");
            DropForeignKey("dbo.Pets", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "FavouritePet_Id", "dbo.Pets");
            DropForeignKey("dbo.Pets", "Ownder_Id", "dbo.Customers");
            DropIndex("dbo.FullProps", new[] { "PropertyPattern_Id" });
            DropIndex("dbo.Pets", new[] { "Customer_Id" });
            DropIndex("dbo.Pets", new[] { "Ownder_Id" });
            DropIndex("dbo.Customers", new[] { "FavouritePet_Id" });
            DropColumn("dbo.Customers", "FavouritePet_Id");
            DropTable("dbo.FullProps");
            DropTable("dbo.Pets");
        }
    }
}

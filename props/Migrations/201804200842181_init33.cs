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
        }
        
        public override void Down()
        {
        }
    }
}

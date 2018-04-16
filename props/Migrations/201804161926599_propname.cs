namespace props.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propname : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BaseProperties", "PropertyType_Id", "dbo.PropertyTypes");
            DropIndex("dbo.BaseProperties", new[] { "PropertyType_Id" });
            RenameColumn(table: "dbo.BaseProperties", name: "PropertyType_Id", newName: "PropertyTypeId");
            AlterColumn("dbo.BaseProperties", "PropertyTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.BaseProperties", "PropertyTypeId");
            AddForeignKey("dbo.BaseProperties", "PropertyTypeId", "dbo.PropertyTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.BaseProperties", "PropertyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BaseProperties", "PropertyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BaseProperties", "PropertyTypeId", "dbo.PropertyTypes");
            DropIndex("dbo.BaseProperties", new[] { "PropertyTypeId" });
            AlterColumn("dbo.BaseProperties", "PropertyTypeId", c => c.Int());
            RenameColumn(table: "dbo.BaseProperties", name: "PropertyTypeId", newName: "PropertyType_Id");
            CreateIndex("dbo.BaseProperties", "PropertyType_Id");
            AddForeignKey("dbo.BaseProperties", "PropertyType_Id", "dbo.PropertyTypes", "Id");
        }
    }
}

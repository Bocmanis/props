namespace props.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedpropertiesname : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Properties", newName: "BaseProperties");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BaseProperties", newName: "Properties");
        }
    }
}

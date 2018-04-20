namespace props.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpatternssss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertyPatterns",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PropertyPatterns");
        }
    }
}

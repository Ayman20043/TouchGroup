namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HomeImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "IsActive");
        }
    }
}

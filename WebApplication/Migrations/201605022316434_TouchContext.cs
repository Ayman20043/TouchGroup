namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TouchContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeamMembers", "Extention", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeamMembers", "Extention");
        }
    }
}

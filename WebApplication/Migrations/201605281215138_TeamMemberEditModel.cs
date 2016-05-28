namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamMemberEditModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeamMembers", "Phone", c => c.String());
            AddColumn("dbo.TeamMembers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeamMembers", "Email");
            DropColumn("dbo.TeamMembers", "Phone");
        }
    }
}

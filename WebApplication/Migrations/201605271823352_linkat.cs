namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialLinks", "pinterest", c => c.String());
            AddColumn("dbo.SocialLinks", "GooglePlus", c => c.String());
            DropColumn("dbo.SocialLinks", "twitter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SocialLinks", "twitter", c => c.String());
            DropColumn("dbo.SocialLinks", "GooglePlus");
            DropColumn("dbo.SocialLinks", "pinterest");
        }
    }
}

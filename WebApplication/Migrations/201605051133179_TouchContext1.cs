namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TouchContext1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactUs", "PhoneEgy", c => c.String());
            AddColumn("dbo.ContactUs", "FaxEgy", c => c.String());
            AddColumn("dbo.ContactUs", "PhoneUAE", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactUs", "PhoneUAE");
            DropColumn("dbo.ContactUs", "FaxEgy");
            DropColumn("dbo.ContactUs", "PhoneEgy");
        }
    }
}

namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TouchContext1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ContactUs", "PhoneEgy");
            DropColumn("dbo.ContactUs", "PhoneUAE");
            DropColumn("dbo.ContactUs", "FaxUAE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactUs", "FaxUAE", c => c.String());
            AddColumn("dbo.ContactUs", "PhoneUAE", c => c.String());
            AddColumn("dbo.ContactUs", "PhoneEgy", c => c.String());
        }
    }
}

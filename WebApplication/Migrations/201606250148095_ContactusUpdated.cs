namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactusUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactUs", "MailEGY", c => c.String());
            AddColumn("dbo.ContactUs", "MailUAE", c => c.String());
            DropColumn("dbo.ContactUs", "PhoneEgy");
            DropColumn("dbo.ContactUs", "PhoneUAE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactUs", "PhoneUAE", c => c.String());
            AddColumn("dbo.ContactUs", "PhoneEgy", c => c.String());
            DropColumn("dbo.ContactUs", "MailUAE");
            DropColumn("dbo.ContactUs", "MailEGY");
        }
    }
}

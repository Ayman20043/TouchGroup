namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TouchContext2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactUs", "FaxUAE", c => c.String());
            DropColumn("dbo.ContactUs", "FaxEgy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactUs", "FaxEgy", c => c.String());
            DropColumn("dbo.ContactUs", "FaxUAE");
        }
    }
}

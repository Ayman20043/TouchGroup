namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactUsMessage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUsMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        From = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                        IsRead = c.Boolean(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactUsMessages");
        }
    }
}

namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackgroundImagesAddedd : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.BackgroundImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BackgroundImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleColor = c.String(),
                        Extention = c.String(),
                        PicturePath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

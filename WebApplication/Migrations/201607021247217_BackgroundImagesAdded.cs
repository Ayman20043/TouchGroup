namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackgroundImagesAdded : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.BackgroundImages");
        }
    }
}

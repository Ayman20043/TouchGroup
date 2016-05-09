namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eman : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Facebook = c.String(),
                        twitter = c.String(),
                        Instgrame = c.String(),
                        LinkedIn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SocialLinks");
        }
    }
}

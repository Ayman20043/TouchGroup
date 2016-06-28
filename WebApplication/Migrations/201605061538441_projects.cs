namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Area = c.Int(nullable: false),
                        Client = c.String(),
                        LogoPath = c.String(),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "SubCategoryId" });
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropTable("dbo.Projects");
        }
    }
}

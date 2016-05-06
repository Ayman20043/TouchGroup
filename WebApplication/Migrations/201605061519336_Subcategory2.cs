namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subcategory2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropPrimaryKey("dbo.SubCategories");
            AlterColumn("dbo.SubCategories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SubCategories", "Id");
            AddForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropTable("dbo.Projects");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.SubCategories");
            AlterColumn("dbo.SubCategories", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SubCategories", "CategoryId");
            CreateIndex("dbo.Projects", "CategoryId");
            AddForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Projects", "CategoryId", "dbo.SubCategories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}

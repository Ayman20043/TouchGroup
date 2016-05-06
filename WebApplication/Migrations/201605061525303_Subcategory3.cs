namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subcategory3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropTable("dbo.SubCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.SubCategories", "CategoryId");
            AddForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}

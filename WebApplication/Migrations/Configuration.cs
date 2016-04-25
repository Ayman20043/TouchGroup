using WebApplication.Models;

namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication.TouchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication.TouchContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.CompanyProfiles.AddOrUpdate(x => x.Id,
              new CompanyProfile() { Id = 1, SectionName = "Introduction" },
              new CompanyProfile() { Id = 2, SectionName = "Philosophy" },
              new CompanyProfile() { Id = 3, SectionName = "Main Objectives" },
              new CompanyProfile() { Id = 4, SectionName = "Portfolio of Services" }
              );
        }
    }
}

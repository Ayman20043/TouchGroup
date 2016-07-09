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
            context.CareerInformation.AddOrUpdate(
             p=>p.Id,
             new CareerInfo() { Id=1,Content = " "}
            );
            context.BackgroundImages.AddOrUpdate(
         g=> g.Id,
         new BackgroundImage() { Id = 1 },
          new BackgroundImage() { Id = 2 },
           new BackgroundImage() { Id = 3 }
        );
            //context.ContactUsMessages.AddOrUpdate(
            //    new Models.ContactUsMessage
            //    {
            //        Id = 1,
            //        Name = "Aliaa Omar",
            //        From = "Aliaa@touchgroup.org",
            //        Message = "EEEEEEEEEEEEEEEEEEEEEE",
            //        IsRead = true,
            //        SendDate = DateTime.Now,
            //        Subject = "Arch Job"
            //    },
            //     new Models.ContactUsMessage
            //     {
            //         Id = 2,
            //         Name = "Mohamed",
            //         From = "Mohamed@touchgroup.org",
            //         Message = "EEEEEEEEEEEEEEEEEEEEEE",
            //         IsRead = false,
            //         SendDate = DateTime.Now,
            //         Subject = "Civil Engineer"
            //     },
            //      new Models.ContactUsMessage
            //      {
            //          Id = 3,
            //          Name = "Ayman",
            //          From = "Ayman@touchgroup.org",
            //          Message = "EEEEEEEEEEEEEEEEEEEEEE",
            //          IsRead = false,
            //          SendDate = DateTime.Now,
            //          Subject = "Arch Job"
            //      },
            //       new Models.ContactUsMessage
            //       {
            //           Id = 4,
            //           Name = "Suzan Omar",
            //           From = "Sozita@touchgroup.org",
            //           Message = "EEEEEEEEEEEEEEEEEEEEEE",
            //           IsRead = false,
            //           SendDate = DateTime.Now,
            //           Subject = "Arch Job"
            //       },
            //         new Models.ContactUsMessage
            //         {
            //             Id = 5,
            //             Name = "Sara Mohamed",
            //             From = "Saramohamed@touchgroup.org",
            //             Message = "EEEEEEEEEEEEEEEEEEEEEE",
            //             IsRead = true,
            //             SendDate = DateTime.Now,
            //             Subject = "Arch Job"
            //         }
            //    );

            //context.CareerInformation.AddOrUpdate(
            //    new Models.CareerInfo {
            //        Id=1,
            //        Content=string.Empty
            //    }
            //    );
        }
    }
}

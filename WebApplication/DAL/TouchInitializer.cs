using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.DAL
{
    public class TouchInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TouchContext>
    {
        protected override void Seed(TouchContext context)
        {
            base.Seed(context);
        }
    }
}
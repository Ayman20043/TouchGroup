using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
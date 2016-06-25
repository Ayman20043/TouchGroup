using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        [Route(Name = "About")]
        public ActionResult Index(string id)
        {
            using (TouchContext db=new TouchContext())
            {
               
                return View(db.CompanyProfiles.Single(e => e.SectionName.ToLower() == id.ToLower()));
            }
            
        }

    }
}
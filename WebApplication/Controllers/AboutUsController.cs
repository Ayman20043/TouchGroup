using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        public ActionResult Index()
        {
            using (TouchContext db = new TouchContext())
            {
                return View(db.CompanyProfiles.ToList());
            }

        }
    }
}
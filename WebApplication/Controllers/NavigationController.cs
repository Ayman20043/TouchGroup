using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUsLinks()
        {

            using (TouchContext db=new TouchContext())
            {
                return PartialView(db.CompanyProfiles.ToList()); 
            }
        }
        public ActionResult SocialLinks()
        {

            using (TouchContext db = new TouchContext())
            {
                return PartialView(db.SocialLinks.FirstOrDefault());
            }
        }

    }
}
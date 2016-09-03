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

        public ActionResult Download()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/File/Portfolio/TCG-PRE COALIFICATION-v9-small.pdf"));
            string fileName = "TCG-PRE COALIFICATION.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}
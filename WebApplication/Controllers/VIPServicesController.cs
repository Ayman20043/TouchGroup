using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class VIPServicesController : Controller
    {
        // GET: VIPServices
        public ActionResult Index()
        {
            using (TouchContext db = new TouchContext())
            {
                return View(db.VipServices.ToList());
            }
        }
    }
}
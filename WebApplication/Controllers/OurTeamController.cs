using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class OurTeamController : Controller
    {
        // GET: OurTeam
        public ActionResult Index()
        {
            using (TouchContext db=new TouchContext())
            {
                return View(db.TeamMembers.ToList());
            }
          
        }
    }
}
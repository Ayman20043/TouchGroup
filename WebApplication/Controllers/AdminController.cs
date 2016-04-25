using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    if (db.ContactUs.Any())
                    {
                        var existingRow = db.ContactUs.FirstOrDefault();
                        return View(existingRow);
                    }
                    else
                    {
                        return View(new ContactUs());
                    }
                }
            }
            catch (Exception)
            {
                //Todo Write Some Exception Logging Technique 
                // throw;
            }
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactUs input)
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    if (input.Id > 0)
                    {
                        db.Entry(input).State = EntityState.Modified;
                    }
                    else
                    {
                        db.ContactUs.Add(input);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                // throw;
            }
            return View();
        }
        public ActionResult TeamMembers()
        {
            using (TouchContext touch=new TouchContext())
            {
                 return View(touch.TeamMembers.ToList());
            }
           

        }

        public ActionResult AddTeamMembers()
        {

            return View();

        }
        [HttpPost]
        public ActionResult AddTeamMembers(TeamMember Newmember)
        {
            try
            {
                using (TouchContext touch=new TouchContext())
                {
                    touch.TeamMembers.Add(Newmember);
                    touch.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                
            }
            return View(Newmember);

        }

    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        public HttpStatusCodeResult ContactUs(ContactUs input)
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
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                // throw;
            }
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        public ActionResult TeamMembers()
        {
            using (TouchContext touch = new TouchContext())
            {
                return View(touch.TeamMembers.ToList());
            }


        }

        public ActionResult AddTeamMembers()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddTeamMembers(TeamMember newmember)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    touch.TeamMembers.Add(newmember);
                    touch.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Redirect("~/Admin/TeamMembers");
        }

        public ActionResult EditeTeamMembers(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    var edited = touch.TeamMembers.FirstOrDefault(a => a.Id == id);
                    return View(edited);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult EditeTeamMembers(TeamMember member)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    touch.Entry(member).State = EntityState.Modified;
                    touch.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return Redirect("~/Admin/TeamMembers");
        }


        public ActionResult detailsTeamMember(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    //var details = touch.TeamMembers.FirstOrDefault(a => a.Id == id);
                    var details = touch.TeamMembers.Find(id);
                    return View(details);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult deleteTeamMember(int? id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    //var details = touch.TeamMembers.FirstOrDefault(a => a.Id == id);
                    var details = touch.TeamMembers.Find(id);
                    return View(details);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult deleteTeamMember(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    var details = touch.TeamMembers.Find(id);
                    touch.TeamMembers.Remove(details);
                    touch.SaveChanges();
                   
                }
                return Redirect("~/Admin/TeamMembers");

            }
            catch (Exception)
            {

                throw;
            }

        }




    }
}
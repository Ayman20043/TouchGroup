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

        public ActionResult AddMember()
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
        public ActionResult AddMember(TeamMember newmember)
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

        public ActionResult EditMember(int id)
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
        public ActionResult EditMember(TeamMember member)
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


        public ActionResult MemberDetails(int id)
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

        public ActionResult DeleteMember(int? id)
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
        public ActionResult DeleteMember(int id)
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


        public ActionResult Introduction()
        {
            try
            {
                using (TouchContext db=new TouchContext())
                {
                    var intro = db.CompanyProfiles.FirstOrDefault(x => x.Id == 1);
                    if (intro != null)
                   return View(intro);
                   return View(new CompanyProfile() {Id = 1, Content = "Introduction", SectionName = "Introduction"});
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Introduction(CompanyProfile input)
        {
            try
            {
                using (TouchContext db=new TouchContext())
                {
                    db.Entry(input).State=EntityState.Modified;
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




        public ActionResult Philosophy()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    var Philo = db.CompanyProfiles.FirstOrDefault(x => x.Id == 2);
                    if (Philo != null)
                        return View(Philo);
                    return View(new CompanyProfile() { Id = 2, Content = "Philosophy", SectionName = "Philosophy" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Philosophy(CompanyProfile input)
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    db.Entry(input).State = EntityState.Modified;
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



        public ActionResult Objectives()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    var Objectives = db.CompanyProfiles.FirstOrDefault(x => x.Id == 3);
                    if (Objectives != null)
                        return View(Objectives);
                    return View(new CompanyProfile() { Id = 3, Content = "Objectives", SectionName = "Main Objectives" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Objectives(CompanyProfile input)
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    db.Entry(input).State = EntityState.Modified;
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


        public ActionResult Services()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    var Services = db.CompanyProfiles.FirstOrDefault(x => x.Id == 4);
                    if (Services != null)
                        return View(Services);
                    return View(new CompanyProfile() { Id = 4, Content = "Services", SectionName = "Portfolio of Services" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Services(CompanyProfile input)
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    db.Entry(input).State = EntityState.Modified;
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


    }
}
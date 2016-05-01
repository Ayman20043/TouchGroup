using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.ViewModel;
using WebApplication.Helpers;

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

        public ActionResult Introduction()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    var intro = db.CompanyProfiles.FirstOrDefault(x => x.Id == 1);
                    if (intro != null)
                        return View(intro);
                    return View(new CompanyProfile() { Id = 1, Content = "Introduction", SectionName = "Introduction" });
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

        public ActionResult Projects()
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


        public ActionResult Team()
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    return View(touch.TeamMembers.ToList());
                }
            }
            catch (Exception ex)
            {


            }
            return View();
        }

        public JsonResult GetMember(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    var member = touch.TeamMembers.SingleOrDefault(A => A.Id == id);
                    return Json(member, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult CreatMember(TeamMemberViewModel Input)
        {
            try
            {
                if (Input.PicturePath != null && Input.CvPath != null)
                {
                    Input.PicturePath.SaveAs(HttpContext.
                        Server.MapPath("~/Images/Profile/")+ Input.PicturePath.FileName);
                    Input.CvPath.SaveAs(HttpContext.Server.MapPath("~/File/")+ Input.CvPath.FileName);
                    var resizedImage = Helpers.ImageResizeHelper.FixedSize(Image.FromStream(Input.PicturePath.InputStream), 50, 50);
                    resizedImage.Save();
                }
                using (TouchContext touch = new TouchContext())
                {

                    touch.TeamMembers.Add
                        (new TeamMember()
                        {
                            Name = Input.Name,
                            Position = Input.Position,
                            Details = Input.Details,
                            PicturePath = Input.PicturePath.FileName + DateTime.Now,
                            CvPath = Input.CvPath.FileName + DateTime.Now
                        });
                    touch.SaveChanges();
                }
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTeamPartial()
        {
            using (TouchContext db = new TouchContext())
            {
                return PartialView("_Partial", db.TeamMembers.ToList());
            }

        }

        public ActionResult Savemember(TeamMember Input)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    touch.Entry(Input).State = EntityState.Modified;
                    touch.SaveChanges();
                }

            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }


        public ActionResult DeleteRow(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {

                    var del = touch.TeamMembers.FirstOrDefault(a => a.Id == id);
                    touch.TeamMembers.Remove(del);
                    touch.SaveChanges();
                }
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }


    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
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

        #region//ContactUs
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
        #endregion



        #region //Team Members
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
        [HttpPost]
        public ActionResult CreatMember(TeamMemberViewModel Input)
        {
            try
            {
                var Date = DateTime.Now.ToFileTimeUtc();
                String[] Arr = Input.PicturePath.FileName.Split('.');
                String[] Arry = Input.CvPath.FileName.Split('.');
                if (Input.PicturePath != null && Input.CvPath != null)
                {
                    Input.PicturePath.SaveAs(HttpContext.
                        Server.MapPath("~/Images/Profile/") + Arr[0] + Date + "_L." + Arr[1]);
                    if (Arry[1]== "pdf")
                    {
                        Input.CvPath.SaveAs(HttpContext.Server.MapPath("~/File/") + Input.CvPath.FileName + Date);
                    }
                    Bitmap b =new Bitmap (Input.PicturePath.InputStream);
                    var resizedImage = Helpers.ImageResizeHelper.ResizeBitmap(b, 100, 100);
                    resizedImage.Save(HttpContext.
                        Server.MapPath("~/Images/Profile/Display/") + Arr[0] + Date + "_S." + Arr[1]);
                }
                using (TouchContext touch = new TouchContext())
                {   
                                
                    touch.TeamMembers.Add
                        (new TeamMember()
                        {
                            Name = Input.Name,
                            Position = Input.Position,
                            Details = Input.Details,
                            Extention = Arr[1],
                            PicturePath = Arr[0] + Date,
                            CvPath = Input.CvPath.FileName
                        });
                    touch.SaveChanges();
                }
            }
            catch (Exception ex)
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

        public ActionResult Savemember(TeamMemberViewModel Input)
        {
            try
            {
                TeamMember Member = new TeamMember();
                var Date = DateTime.Now.ToFileTimeUtc();
                Member = new TeamMember()
                {
                    Id = Input.Id,
                    Name = Input.Name,
                    Position = Input.Position,
                    Details = Input.Details,
                };
                using (TouchContext touch = new TouchContext())
                {
                    if (Input.PicturePath != null)
                    {
                        string[] Arr = Input.PicturePath.FileName.Split('.');
                        Input.PicturePath.SaveAs(HttpContext.Server.MapPath("~/Images/Profile/") + Arr[0] + Date + "_L." + Arr[1]);
                        Bitmap b = new Bitmap(Input.PicturePath.InputStream);
                        var resizedImage = Helpers.ImageResizeHelper.FixedSize(b, 100, 100);
                        resizedImage.Save(HttpContext.Server.MapPath("~/Images/Profile/Display/") + Arr[0] + Date + "_S." + Arr[1]);
                        Member.PicturePath = Arr[0] + Date;
                        Member.Extention = Arr[1];

                    }
                    if (Input.CvPath != null)
                    {
                        Input.CvPath.SaveAs(HttpContext.Server.MapPath("~/File/") + Input.CvPath.FileName + Date);
                        Member.CvPath = Input.CvPath.FileName;
                    }
                    touch.Entry(Member).State = EntityState.Modified;
                    touch.SaveChanges();
                }

            }
            catch (Exception ex)
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

        #endregion

        #region //Project 
        public ActionResult Projects()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {

                    List<Category> cat = new List<Category>(db.Categories.ToList());
                    SelectList CatList = new SelectList(cat, "Id", "Name");
                    ViewBag.CategoryList = CatList;

                    return View(db.Projects.ToList());
                }
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetProject(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    var project = touch.Projects.SingleOrDefault(A => A.Id == id);
                    return Json(project, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult AddProject(ProjectViewModel Input)
        {
            try
            {
                var Date = DateTime.Now.ToFileTimeUtc();
                if (Input.LogoPath != null)
                {
                    var resizedImage = Helpers.ImageResizeHelper.FixedSize(Image.FromStream(Input.LogoPath.InputStream), 100, 100);
                    resizedImage.Save(HttpContext.
                        Server.MapPath("~/Images/logo/") + Date);
                }

                using (TouchContext touch = new TouchContext())
                {
                    touch.Projects.Add
                        (new Project()
                        {
                            Name = Input.Name,
                            Location = Input.Location,
                            Area = Input.Area,
                            Client = Input.Client,
                            LogoPath = Input.LogoPath.FileName + Date,
                            Category = Input.Category,
                            SubCategory = Input.SubCategory
                        });
                    touch.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult GetAllProjects()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    return PartialView("_ProjectsPartial", db.Projects.ToList());
                }
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteProject(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    var del = touch.Projects.FirstOrDefault(a => a.Id == id);
                    touch.Projects.Remove(del);
                    touch.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveProject()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {

                }
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Fill(int id)
        {
            using (TouchContext touch = new TouchContext())
            {
                var subCat = touch.SubCategories.Where(a => a.CategoryId == id);
                return Json(subCat, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


        #region//Social Links
        public ActionResult SocialLink()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    if (db.SocialLinks.Any())
                    {
                        var existingRow = db.SocialLinks.FirstOrDefault();
                        return View(existingRow);
                    }
                    else
                    {
                        return View(new SocialLink());
                    }
                }
            }
            catch (Exception)
            {

            }
            return View();
        }

        [HttpPost]
        public HttpStatusCodeResult SocialLink(SocialLink input)
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
                        db.SocialLinks.Add(input);
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
        #endregion


        #region //Company Profile
        public ActionResult CompanyProfile()
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    return View(touch.CompanyProfiles.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult EditProfile(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    var find = touch.CompanyProfiles.FirstOrDefault(a => a.Id == id);
                    return View(find);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditProfile(CompanyProfile input)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    touch.Entry(input).State = EntityState.Modified;
                    touch.SaveChanges();
                    return Redirect("~/Admin/CompanyProfile");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult DeleteProfile(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    var del = touch.CompanyProfiles.FirstOrDefault(a => a.Id == id);
                    touch.CompanyProfiles.Remove(del);
                    touch.SaveChanges();

                }
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Redirect("~/Admin/CompanyProfile");
        }

        public ActionResult ProfileDetails(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    return View(touch.CompanyProfiles.FirstOrDefault(a => a.Id == id));
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public ActionResult AddProfile()
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    return View();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddProfile(CompanyProfile Add)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    touch.CompanyProfiles.Add(Add);
                    touch.SaveChanges();
                    return Redirect("~/Admin/CompanyProfile");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

    }
}
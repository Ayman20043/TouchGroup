using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
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
    [HandleError(View = "Error")]
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return RedirectToAction("CompanyProfile");
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
                    if (Arry[1] == "pdf")
                    {
                        Input.CvPath.SaveAs(HttpContext.Server.MapPath("~/File/MemberCv/") + Input.CvPath.FileName );
                    }
                    Bitmap b = new Bitmap(Input.PicturePath.InputStream);
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
                            CvPath = Input.CvPath.FileName,
                            Email=Input.Email,
                            Phone=Input.Phone
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

        public ActionResult GetPartial()
        {
            using (TouchContext db = new TouchContext())
            {
                return PartialView("_TeamPartial", db.TeamMembers.ToList());
            }

        }
        public ActionResult Savemember(TeamMemberViewModel Input)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    var obj = touch.TeamMembers.Where(a => a.Id == Input.Id).FirstOrDefault();
                    obj.Id = Input.Id;
                    obj.Name = Input.Name;
                    obj.Position = Input.Position;
                    obj.Details = Input.Details;
                    obj.Email = Input.Email;
                    obj.Phone = Input.Phone;

                    var Date = DateTime.Now.ToFileTimeUtc();
                    if (Input.PicturePath != null)
                    {
                        string[] Arr = Input.PicturePath.FileName.Split('.');
                        Input.PicturePath.SaveAs(HttpContext.Server.MapPath("~/Images/Profile/") + Arr[0] + Date + "_L." + Arr[1]);
                        Bitmap b = new Bitmap(Input.PicturePath.InputStream);
                        var resizedImage = Helpers.ImageResizeHelper.ResizeBitmap(b, 100, 100);
                        resizedImage.Save(HttpContext.Server.MapPath("~/Images/Profile/Display/") + Arr[0] + Date + "_S." + Arr[1]);
                        obj.PicturePath = Arr[0] + Date;
                        obj.Extention = Arr[1];

                    }
                    if (Input.CvPath != null)
                    {
                        Input.CvPath.SaveAs(HttpContext.Server.MapPath("~/File/MemberCv/") + Input.CvPath.FileName);
                        obj.CvPath = Input.CvPath.FileName;
                    }
                    touch.Entry(obj).State = EntityState.Modified;
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
        [Authorize]
        public ActionResult Projects()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {

                    List<Category> cat = new List<Category>(db.Categories.ToList());
                    SelectList CatList = new SelectList(cat, "Id", "Name");
                    ViewBag.CategoryList = CatList;

                    return View(db.Projects.Include("SubCategory").ToList());
                }
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
        [Authorize]
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
        [Authorize]
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
                            SubCategory = Input.SubCategory,
                            IsActive = Input.IsActive
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
        [Authorize]
        public ActionResult ProjectForm(int? id)
        {
            var model = new ProjectViewModel();
            using (TouchContext db = new TouchContext())
            {
                if (id!=null && id >0)
                {
                    var obj = db.Projects.Include("ProjectImages").FirstOrDefault(a => a.Id == id);
                    model=new ProjectViewModel(obj);
                }
                List<Category> cat = new List<Category>(db.Categories.ToList());
                SelectList CatList = new SelectList(cat, "Id", "Name");
                ViewBag.CategoryList = CatList;
            }
            return View(model);
        }

        public ActionResult DeleteProjectImage(int id)
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    var image = db.ProjectsImages.Single(e => e.Id == id);
                    db.ProjectsImages.Remove(image);
                    System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Projects/Temp"), image.FileName));
                    db.SaveChanges();

                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {


                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult ProjectForm(ProjectViewModel input,string imagesNames)
        {
            using (TouchContext db = new TouchContext())
            {
                var Date = DateTime.Now.ToFileTimeUtc();
                string[] arr = input.LogoPath?.FileName.Split('.');
                Project project;
                if (input.Id == 0)
                {
                    project = new Project()
                    {
                        Area = input.Area,
                        Client = input.Client,
                        Location = input.Location,
                        Name = input.Name,
                        IsActive = input.IsActive,
                        CategoryId = input.CategoryId,
                        SubCategoryId = input.SubCategoryId,
                        //LogoPath = input.LogoPath.FileName.Split('.').First() + Date+"."+ input.LogoPath.FileName.Split('.').Last()
                    };
                   
                    if (arr != null)
                        project.LogoPath = arr[0] + Date + "." + arr[1];
                    db.Projects.Add(project);
                    db.SaveChanges();
                }
                else
                {
                    project = db.Projects.Single(e => e.Id == input.Id);
                    project.Area = input.Area;
                    project.Client = input.Client;
                    project.Location = input.Location;
                    project.Name = input.Name;
                    project.IsActive = input.IsActive;
                    project.CategoryId = input.CategoryId;
                    project.SubCategoryId = input.SubCategoryId;
                    if (input.LogoPath != null)
                     project.LogoPath = project.LogoPath = arr[0] + Date + "." + arr[1];
                }
                if (input.LogoPath != null)
                {
                    var resizedImage = Helpers.ImageResizeHelper.ResizeBitmap(new Bitmap(input.LogoPath.InputStream), 100, 100);
                    resizedImage.Save(HttpContext.Server.MapPath("~/Images/logo/") + arr[0] + Date + "." + arr[1]);
                }
                var selectedImagesNames = imagesNames.Split(',');
                if (selectedImagesNames.Length > 0)
                {
                    List<ProjectImage> images = new List<ProjectImage>();
                    foreach (var item in selectedImagesNames)
                    {
                        if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Images/Projects/Temp"), item)))
                        {
                            var file = item.Split('.').First() + Date + "." + item.Split('.').Last();
                            System.IO.File.Copy(Path.Combine(Server.MapPath("~/Images/Projects/Temp"), item), Path.Combine(Server.MapPath("~/Images/Projects/"), file));
                            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Projects/Temp"), item));
                            images.Add(new ProjectImage() { FileName = file, ProjectId = project.Id });
                        }
                    }
                    db.ProjectsImages.AddRange(images);
                    db.SaveChanges();
                }
                System.IO.DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Images/Projects/Temp"));
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                List<Category> cat = new List<Category>(db.Categories.ToList());
                SelectList CatList = new SelectList(cat, "Id", "Name");
                ViewBag.CategoryList = CatList;
                return Redirect("~/Admin/Projects");
            }
        }

        [HttpPost]
        public ActionResult DeleteImage()
        {
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                // string savedFileName = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(hpf.FileName));
                /*  hpf.SaveAs(savedFileName);*/ // Save the file

                //r.Add(new ViewDataUploadFilesResult()
                //{
                //    Name = hpf.FileName,
                //    Length = hpf.ContentLength,
                //    Type = hpf.ContentType
                //});
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AsycnImageUpload()
         {
          //  var r = new List<ViewDataUploadFilesResult>();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;
                string savedFileName = Path.Combine(Server.MapPath("~/Images/Projects/Temp"), Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName); // Save the file
                //r.Add(new ViewDataUploadFilesResult()
                //{
                //    Name = hpf.FileName,
                //    Length = hpf.ContentLength,
                //    Type = hpf.ContentType
                //});
            }

            return Json(true,JsonRequestBehavior.AllowGet);
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
                var subCat = touch.SubCategories.Where(a => a.CategoryId == id).ToList();
                return Json(subCat, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult addCategory(Category input)
        {
            using (TouchContext db = new TouchContext())
            {
              
                    db.Categories.Add(input);
                    db.SaveChanges();
                
            }
            return Json(input, JsonRequestBehavior.AllowGet);
        }

        public ActionResult addSubCategory(SubCategory input)
        {
            using (TouchContext db = new TouchContext())
            {
                db.SubCategories.Add(input);
                db.SaveChanges();
            }
            return Json(input, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteCategory(int id)
        {
            using (TouchContext db = new TouchContext())
            {
                var del = db.Categories.FirstOrDefault(a=>a.Id==id);
                db.Categories.Remove(del);
                db.SaveChanges();
                var list = db.Categories.ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }           
        }


        public ActionResult DeleteSubCategory(int id)
        {
            using (TouchContext db = new TouchContext())
            {
                var del = db.SubCategories.FirstOrDefault(a => a.Id == id);
                int catId = del.CategoryId;
                db.SubCategories.Remove(del);
                db.SaveChanges();
                var list = db.SubCategories.Where(e => e.CategoryId == catId).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ChecProjectCat(int id)
        {
            using (TouchContext db = new TouchContext())
            {
                var ptoj = db.Projects.Where(a=>a.CategoryId==id).Count();                
                return Json(ptoj, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ChecProjectSubCat(int id)
        {
            using (TouchContext db = new TouchContext())
            {
                var ptoj = db.Projects.Where(a => a.SubCategoryId == id).Count();
                return Json(ptoj, JsonRequestBehavior.AllowGet);
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

        public ActionResult GetCompanyPartial()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    return PartialView("_CompanyProfilePartial", db.CompanyProfiles.ToList());
                }
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
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
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [ValidateInput(false)]
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
            //throw new Exception();
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


        #region Background Images
        public ActionResult BackgroundImage()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    return View(db.BackgroundImages.ToList());
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult GetBackroundImage(int id)
        {
            using (TouchContext db=new TouchContext())
            {
                return Json(db.BackgroundImages.Single(e => e.Id == id),JsonRequestBehavior.AllowGet);
            }
        }

        #endregion


        #region //Home Images

        public ActionResult HomeImage()
        {
            try
            {
                using (TouchContext db = new TouchContext())
                {
                    return View(db.HomeImages.ToList());
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult GetHomePartial()
        {
            using (TouchContext db = new TouchContext())
            {
                return PartialView("_HomeImagePartial", db.HomeImages.ToList());
            }

        }
        public ActionResult CreatHome(HomeImageViewModel Input)
        {
            try
            {
                var Date = DateTime.Now.ToFileTimeUtc();
                String[] Arr = Input.PicturePath.FileName.Split('.');
                if (Input.PicturePath != null)
                {
                    Input.PicturePath.SaveAs(HttpContext.
                        Server.MapPath("~/Images/backgrounds/") + Arr[0] + Date + "_L." + Arr[1]);
                    Bitmap b = new Bitmap(Input.PicturePath.InputStream);
                    var resizedImage = Helpers.ImageResizeHelper.ResizeBitmap(b, 100, 100);
                    resizedImage.Save(HttpContext.
                        Server.MapPath("~/Images/backgrounds/SmallBackGround/") + Arr[0] + Date + "_S." + Arr[1]);
                }
                using (TouchContext touch = new TouchContext())
                {
                    touch.HomeImages.Add
                        (new HomeImage()
                        {
                            Title = Input.Title,
                            Description = Input.Description,
                            Extention = Arr[1],
                            PicturePath = Arr[0] + Date,
                            IsActive = Input.IsActive
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
        public ActionResult SaveHomeImages(HomeImageViewModel Input)
        {
            try
            {
                var Date = DateTime.Now.ToFileTimeUtc();
                using (TouchContext touch = new TouchContext())
                {
                    var obj = touch.HomeImages.Where(a => a.Id == Input.Id).FirstOrDefault();
                    obj.Title = Input.Title;
                    obj.Description = Input.Title;
                    obj.IsActive = Input.IsActive;
                    if (Input.PicturePath != null)
                    {
                        string[] Arr = Input.PicturePath.FileName.Split('.');
                        Input.PicturePath.SaveAs(HttpContext.Server.MapPath("~/Images/backgrounds/") + Arr[0] + Date + "_L." + Arr[1]);
                        Bitmap b = new Bitmap(Input.PicturePath.InputStream);
                        var resizedImage = Helpers.ImageResizeHelper.ResizeBitmap(b, 100, 100);
                        resizedImage.Save(HttpContext.Server.MapPath("~/Images/backgrounds/SmallBackGround/") + Arr[0] + Date + "_S." + Arr[1]);
                        obj.PicturePath = Arr[0] + Date;
                        obj.Extention = Arr[1];

                    }
                    touch.Entry(obj).State = EntityState.Modified;
                    touch.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetHomeImage(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    var home = touch.HomeImages.SingleOrDefault(A => A.Id == id);
                    return Json(home, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ActionResult DeleteElemnt(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {

                    var del = touch.HomeImages.FirstOrDefault(a => a.Id == id);
                    touch.HomeImages.Remove(del);
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

        public ActionResult HomeIndexTemplete()
        {
            return View();
        }

        #region//Inbox Messages
        public ActionResult ContactUsMessage()
        {
            using (TouchContext db = new TouchContext())
            {
                return View(db.ContactUsMessages.ToList().OrderByDescending(a=>a.SendDate));
            }

        }

        public ActionResult DeleteMessage(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {

                    var del = touch.ContactUsMessages.FirstOrDefault(a => a.Id == id);
                    touch.ContactUsMessages.Remove(del);
                    touch.SaveChanges();
                }
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetMessagePartial()
        {
            using (TouchContext db = new TouchContext())
            {
                return PartialView("_MessagePartial", db.ContactUsMessages.ToList());
            }

        }


        public ActionResult ReadMessage(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    var View = touch.ContactUsMessages.FirstOrDefault(a => a.Id == id);
                    View.IsRead = true;
                    touch.Entry(View).State = EntityState.Modified;
                    touch.SaveChanges();
                    return Json(View, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion
        public ActionResult AllTeamMember()
        {
            using (TouchContext db = new TouchContext())
            {
                return View(db.TeamMembers.ToList());
            }

        }

        #region JobApplication
        public ActionResult JobApplication()
        {
            using (TouchContext db = new TouchContext())
            {
                return View(db.JobApplication.ToList());
            }

        }

        public ActionResult JobrPartial()
        {
            using (TouchContext db = new TouchContext())
            {
                return PartialView("_JobPartial", db.JobApplication.ToList());
            }

        }

        public ActionResult AddCareer(int id)
        {
            using (TouchContext db = new TouchContext())
            {
                return View(db.CareerInformation.FirstOrDefault(a => a.Id==id));             
            }

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddCareer(CareerInfo career)
        {
            using (TouchContext db = new TouchContext())
            {
                //db.CareerInformation.Add(career);
                //var obj = db.CareerInformation.Where(a => a.Id == career.Id).FirstOrDefault();
                db.Entry(career).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("JobApplication");
            }

        }
        public JsonResult GetJob(int id)
        {
            using (TouchContext db = new TouchContext())
            {
                var obj = db.JobApplication.Where(a => a.Id == id).FirstOrDefault();
                return Json(obj,JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult DeleteJob(int id)
        {
            try
            {
                using (TouchContext touch = new TouchContext())
                {
                    var del = touch.JobApplication.FirstOrDefault(a => a.Id == id);
                    touch.JobApplication.Remove(del);
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
    }
}
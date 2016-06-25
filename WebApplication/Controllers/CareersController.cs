using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CareersController : Controller
    {
        // GET: Careers
        public ActionResult Index()
        {
            using (TouchContext db=new TouchContext())
            {
                  return View(new CareersViewModel() { Info = db.CareerInformation.FirstOrDefault() });
            }
          
        }
        [HttpPost]
        public ActionResult Index(CareersViewModel input)
        {
            using (TouchContext db=new TouchContext())
            {
                string extension = Request.Files[0]?.FileName.Split('.').Last();
                string fileName = Request.Files[0]?.FileName.Split('.').First();
                input.Application.CvPath = fileName + DateTime.Now.ToFileTime()+"."+extension;
                var file = Request.Files[0];
                string savedFileName = Path.Combine(Server.MapPath("~/File/JobCv"), Path.GetFileName(input.Application.CvPath));
                file.SaveAs(savedFileName); // Save the file 
                db.JobApplication.Add(input.Application);
                db.SaveChanges();
                input.Application=new JobApplication();
                input.Info = db.CareerInformation.FirstOrDefault();
                input.IsSent = true;
            }
           
           
            return View(input);
        }
    }
}
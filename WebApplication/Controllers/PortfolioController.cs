using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.ViewModel;

namespace WebApplication.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {
            var result = new PortfolioViewModel();
            using (TouchContext db=new TouchContext())
            {
                var projects= db.Projects.Include("Category").Include("ProjectImages").ToList();
                result.Projects=new List<HomeProjectViewModel>();
                foreach (var project in projects)
                {
                    var temp = new HomeProjectViewModel();
                    temp.Id = project.Id;
                    temp.Name=project.Name;
                    temp.Category = project.Category.Name;
                    if (project.SubCategoryId != null && project.SubCategoryId > 0)
                        temp.SubCategory = db.SubCategories.SingleOrDefault(e => e.Id == project.SubCategoryId.Value).Name;
                    if(project.ProjectImages.Any())
                    temp.FileName = project.ProjectImages.FirstOrDefault().FileName;
                    result.Projects.Add(temp);
                }
                result.Categories = db.Categories.Include("Subcategories").ToList();
                result.SubCategories = db.SubCategories.ToList();
            }
            return View(result);
        }

        public ActionResult Project(int id)
        {
            using (TouchContext db=new TouchContext())
            {
                var result = db.Projects.Include("ProjectImages").SingleOrDefault(e => e.Id == id);
                return View(result); 
            }
           
        }
    }
}
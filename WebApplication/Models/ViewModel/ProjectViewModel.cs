using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModel
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Area { get; set; }
        public string Client { get; set; }
        public HttpPostedFileBase LogoPath { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public Boolean IsActive { get; set; }
        public List<HttpPostedFileBase> ProjectImages { get; set; }
    }
}
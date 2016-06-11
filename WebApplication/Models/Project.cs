using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Project
    {
        public Project()
        {
            ProjectImages = new List<ProjectImage>();
        }
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Area { get; set; }
        public string Client { get; set; }
        [Display(Name = "Logo")]

        public string LogoPath { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Sub Category")]

        public SubCategory SubCategory { get; set; }
        public Boolean IsActive { get; set; }
        public List<ProjectImage> ProjectImages { get; set; }


    }
}
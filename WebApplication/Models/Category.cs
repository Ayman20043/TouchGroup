using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Category
    {
        public Category()
        {
            Projects = new List<Project>();
            Subcategories=new List<SubCategory>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<SubCategory> Subcategories { get; set; }
        public virtual List<Project> Projects { get; set; }

    }
}
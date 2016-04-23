using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Category
    {
        public Category()
        {
            Projects = new List<Project>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public SubCategory Subcategory { get; set; }
        public List<Project> Projects { get; set; }

    }
}
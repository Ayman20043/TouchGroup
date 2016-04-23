using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Area { get; set; }
        public string Client { get; set; }
        public string LogoPath { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }


    }
}
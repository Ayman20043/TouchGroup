using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class SubCategory
    {
       public SubCategory()
        {
            Projects = new List<Project>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [Key,ForeignKey("Category")]
        public int CategoryId { get; set; }
      
        public Category Category { get; set; }
        public List<Project> Projects { get; set; }

    }
}
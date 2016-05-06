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
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
      
        public int CategoryId { get; set; }
        //[ForeignKey("CategoriesId")]
        public virtual Category Category { get; set; }
        public virtual List<Project> Projects { get; set; }

    }
}
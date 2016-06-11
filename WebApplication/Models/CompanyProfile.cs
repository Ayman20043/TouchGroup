using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CompanyProfile
    {
        public int Id { get; set; }
        [Display(Name ="Section Name")]
        public string SectionName { get; set; }
        public string Content { get; set; }
    }
}
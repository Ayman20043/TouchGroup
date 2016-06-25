using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Cv")]

        public string CvPath { get; set; }
        [NotMapped]
        public HttpPostedFile Cv { get; set; }
        public bool IsViewed { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Extention { get; set; }
        [Display(Name = "Picture")]

        public string  PicturePath { get; set; }
        public string Details { get; set; }
        [Display(Name = "CV")]

        public string CvPath { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
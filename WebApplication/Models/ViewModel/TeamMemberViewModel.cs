using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModel
{
    public class TeamMemberViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Extention { get; set; }
        public HttpPostedFileBase PicturePath { get; set; }
        public string Details { get; set; }
        public HttpPostedFileBase CvPath { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
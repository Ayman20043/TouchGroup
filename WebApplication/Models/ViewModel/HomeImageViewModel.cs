using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModel
{
    public class HomeImageViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Extention { get; set; }
        public HttpPostedFileBase PicturePath { get; set; }
        public string Description { get; set; }
        public Boolean IsActive { get; set; }
    }
}
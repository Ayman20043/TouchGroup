using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class HomeImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Extention { get; set; }
        public string PicturePath { get; set; }
        public Boolean IsActive { get; set; }

    }
}
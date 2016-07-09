using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class BackgroundImage
    {
        public int Id { get; set; }
        [Display(Name = "Title Color")]
        public string TitleColor { get; set; }
        public string Extention { get; set; }
        [Display(Name = "Picture")]

        public string PicturePath { get; set; }
        public Boolean IsActive { get; set; }
    }
}
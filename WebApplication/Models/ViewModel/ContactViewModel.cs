using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ContactViewModel
    {
        public ContactUs ContactUs { get; set; }
        public ContactUsMessage Message { get; set; }
    }
}
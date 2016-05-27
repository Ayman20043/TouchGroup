using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ContactUsMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public Boolean IsRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}
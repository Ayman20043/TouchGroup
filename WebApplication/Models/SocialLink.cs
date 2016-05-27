using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class SocialLink
    {
        public int Id { get; set; }
        public string Facebook { get; set; }
        public string pinterest { get; set; }
        public string Instgrame { get; set; }
        public string LinkedIn { get; set; }
        public string GooglePlus { get; set; }

    }
}
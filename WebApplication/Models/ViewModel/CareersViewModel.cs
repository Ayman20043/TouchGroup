using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CareersViewModel
    {
        public CareerInfo Info { get; set; }
        public JobApplication Application { get; set; }
        public bool IsSent { get; set; }
    }
}
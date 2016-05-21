using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ProjectImage
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
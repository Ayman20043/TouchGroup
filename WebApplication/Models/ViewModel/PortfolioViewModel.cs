using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.ViewModel;

namespace WebApplication.Models
{
    public class PortfolioViewModel
    {
        public List<HomeProjectViewModel> Projects { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }

    }
}
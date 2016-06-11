using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel(Project input)
        {
            Id = input.Id;
            Name = input.Name;
            Location = input.Location;
            Area = input.Area;
            Client = input.Client;
            LogoPathString = input.LogoPath;
            CategoryId = input.CategoryId;
            SubCategoryId = input.SubCategoryId;
            IsActive = input.IsActive;
            ProjectImages = input.ProjectImages;

        }

        public ProjectViewModel()
        {
                
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Area { get; set; }
        public string Client { get; set; }
        public HttpPostedFileBase LogoPath { get; set; }
        public string LogoPathString { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public Boolean IsActive { get; set; }
        public List<ProjectImage> ProjectImages { get; set; }
        public string[] imagesNames { get; set; }
    }
}
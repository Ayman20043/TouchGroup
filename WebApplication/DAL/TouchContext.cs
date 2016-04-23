using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication
{
    public class TouchContext : DbContext
    {
        public TouchContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<CareerInfo> CareerInformation  { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<SubCategory> SubCategories  { get; set; }
        public DbSet<Project> Projects  { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles  { get; set; }
        public DbSet<ContactUs> ContactUs  { get; set; }
        public DbSet<JobApplication> JobApplication  { get; set; }
        public DbSet<License> Licenses  { get; set; }
        public DbSet<Service> Services  { get; set; }
        public DbSet<TeamMember> TeamMembers  { get; set; }
       
    }
}
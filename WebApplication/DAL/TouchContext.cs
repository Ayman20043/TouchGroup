using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            this.Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
           // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Project>().HasKey(p => p.Id);
            modelBuilder.Entity<Project>().HasOptional(p => p.SubCategory);
            modelBuilder.Entity<Project>().HasRequired(p => p.Category);

        }
        public DbSet<CareerInfo> CareerInformation  { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<SubCategory> SubCategories  { get; set; }
        public DbSet<Project> Projects  { get; set; }
        public DbSet<ProjectImage> ProjectsImages { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles  { get; set; }
        public DbSet<ContactUs> ContactUs  { get; set; }
        public DbSet<JobApplication> JobApplication  { get; set; }
        public DbSet<License> Licenses  { get; set; }
        public DbSet<Service> Services  { get; set; }
        public DbSet<TeamMember> TeamMembers  { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<HomeImage> HomeImages { get; set; }
        public DbSet<ContactUsMessage> ContactUsMessages { get; set; }

    }
}
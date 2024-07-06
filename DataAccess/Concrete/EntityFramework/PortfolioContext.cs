using Castle.Core.Resource;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class PortfolioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=104.247.167.18\\MSSQLSERVER2019;Database=saiderd1_My_Portfolio;User Id=saiderd1_admin;Password=179324865.aA;TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyPortfolio;Trusted_Connection=true");

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Image> Images{ get; set; }
        public DbSet<Job> Jobs{ get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}

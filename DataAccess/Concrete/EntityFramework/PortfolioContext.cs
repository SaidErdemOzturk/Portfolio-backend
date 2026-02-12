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
            if (optionsBuilder.IsConfigured) return;

            var cs = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING");

            if (string.IsNullOrWhiteSpace(cs))
                throw new InvalidOperationException(
                    "SQL_CONNECTION_STRING environment variable is not set.");

            optionsBuilder.UseSqlServer(cs);
        }
        //setx SQL_CONNECTION_STRING "Server=104.247.167.202\\MSSQLSERVER2022;Database=said5125_MyPortfolio;User ID=said5125_MyPortfolio;Password=179324865.aA;TrustServerCertificate=True;"

        //optionsBuilder.UseSqlServer("Server=104.247.167.202\\MSSQLSERVER2022;Database=said5125_MyPortfolio;User ID=said5125_MyPortfolio;Password=179324865.aA;TrustServerCertificate=True;");
        //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=said5125_MyPortfolio;Trusted_Connection=true");
        public DbSet<Project> Projects { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}

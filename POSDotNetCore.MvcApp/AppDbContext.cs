using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POSDotNetCore.MvcApp.Models;

namespace POSDotNetCore.MvcApp
{
	public class AppDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "KABUKIOS",
                InitialCatalog = "POSDotNetCore",
                UserID = "sa",
                Password = "sqlconfig",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogDataModelOnMac> Blogs { get; set; }
    }
}


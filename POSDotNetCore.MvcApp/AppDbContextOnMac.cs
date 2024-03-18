using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POSDotNetCore.MvcApp.Models;

namespace POSDotNetCore.MvcApp
{
	public class AppDbContextOnMac : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "POSDotNetCore",
                UserID = "sa",
                Password = "<Kabukii@123>",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogDataModelOnMac> Blogs { get; set; }
    }
}


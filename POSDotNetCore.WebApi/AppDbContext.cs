using Microsoft.EntityFrameworkCore;
using POSDotNetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSDotNetCore.WebApi
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "KABUKIOS",
                InitialCatalog = "POSDotNetCore01",
                UserID = "sa",
                Password = "sqlconfig",
                TrustServerCertificate = true
            };
        optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);   
        }
        public DbSet<BlogDataModel> Blogs { get; set; }
    }
}

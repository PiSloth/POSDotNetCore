using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using POSDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace POSDotNetCore.DapperExamples
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder _connectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "KABUKIOS",
            InitialCatalog = "POSDotNetCore01",
            UserID = "sa",
            Password = "sqlconfig",
        };
        public void Run()
        {
            //Read();
            //Edit(1);
            Create("PLO", "Phychology", "Nice to geek");
        }

        private void Read()
        {
            //Console.WriteLine("Dapper Running. . .");
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            
                string query = @"SELECT [Blog_Id]
                            ,[Blog_Author]
                            ,[Blog_Title]
                            ,[Blog_Content] From [dbo].[Tbl_Blog]";

                List<BlogDataModel> lst = db.Query<BlogDataModel>(query).ToList();
                foreach (BlogDataModel item in lst)
                {
                    Console.WriteLine(item.Blog_Id);
                    Console.WriteLine(item.Blog_Author);
                    Console.WriteLine(item.Blog_Title);
                    Console.WriteLine(item.Blog_Content);
            }
            
        }
        private void Edit(int id)
        {
            //Console.WriteLine("Dapper Running. . .");
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);

            string query = @"Update [Blog_Id]
                            ,[Blog_Author]
                            ,[Blog_Title]
                            ,[Blog_Content]
                            FROM [dbo].[Tbl_Blog] 
                            WHERE Blog_Id = @Blog_Id";
                            
                           BlogDataModel? item = db.Query(query,new BlogDataModel { Blog_Id = id }).FirstOrDefault();
                            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            Console.WriteLine(item.Blog_Id);
            Console.WriteLine(item.Blog_Author);
            Console.WriteLine(item.Blog_Title);
            Console.WriteLine(item.Blog_Content);


        }

        private void Create(string author, string title, string content)
        {
            //Console.WriteLine("Dapper Running. . .");
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                            ([Blog_Author]
                            ,[Blog_Title]
                            ,[Blog_Content])
                            VALUES (
                             @Blog_Author,
                             @Blog_Title,
                             @Blog_Content)";

            int result = db.Execute(query, new BlogDataModel()
            {
                Blog_Author = author,
                Blog_Title = title,
                Blog_Content = content,
            });

            string message = result > 0 ? "Creating Successful." : "Creating Failed.";
            Console.WriteLine(message);
        }
    }
}

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
            //Create("PLO", "Psychology", "Nice to geek");
            Update(15, "PLO", "Coding", "Nice to code");
            //Delete(13);
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
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogContent);
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
                            
                           BlogDataModel? item = db.Query(query,new BlogDataModel { BlogId = id }).FirstOrDefault();
                            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogContent);


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
                             @BlogContent)";

            int result = db.Execute(query, new BlogDataModel()
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content,
            });

            string message = result > 0 ? "Creating Successful." : "Creating Failed.";
            Console.WriteLine(message);
        }
        private void Update (int id , string author, string  title, string content)
        {
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [Blog_Title] = @Blog_Title
      ,[Blog_Author] = @BlogAuthor
      ,[Blog_Content] = @Blog_Content
 WHERE Blog_Id = @Blog_Id";
            BlogDataModel blog = new BlogDataModel() {
            BlogId = id,
            BlogAuthor = author,
            BlogTitle = title,
            BlogContent = content,
            };
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }
        private void Delete (int id)
        {
            Console.WriteLine($"{id}");
            using IDbConnection dbConnection = new SqlConnection(_connectionStringBuilder.ConnectionString);

            string query = @$"DELETE FROM [dbo].[Tbl_Blog]
      WHERE Blog_Id = @Blog_Id";
            BlogDataModel blog = new BlogDataModel()
            {
                BlogId = id,
            };
            int result = dbConnection.Execute(query, blog);

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);

        }
    }
}

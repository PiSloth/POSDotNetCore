using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSDotNetCore.AdoDotNetExamples
{
    internal class AdoDotNetExample
    {
        public void Run()
        {
            Read();
            Edit(17);
            Create("Monkii", "Advangers", "What doesn't kill you make you stronger");
            Delete(17);

        }
        private void Read()
        {
            //  Console.WriteLine("Read");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "KABUKIOS",
                InitialCatalog = "POSDotNetCore01",
                UserID = "sa",
                Password = "sqlconfig",
            };
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"SELECT [Blog_Id]
      ,[Blog_Title]
      ,[Blog_Author]
      ,[Blog_Content]
  FROM [dbo].[Tbl_Blog]";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine($"Blog Id => {dr["Blog_Id"]}");
                    Console.WriteLine($"Blog Author => {dr["Blog_Author"]}");
                    Console.WriteLine($"Blog Title => {dr["Blog_Title"]}");
                    Console.WriteLine($"Blog Content => {dr["Blog_Content"]}");
                    Console.WriteLine("- - - - - - - - - - - - - - -  - - - - - \n");
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }

        //Edit
        private void Edit(int id)
        {
            //  Console.WriteLine("Read");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "KABUKIOS",
                InitialCatalog = "POSDotNetCore01",
                UserID = "sa",
                Password = "sqlconfig",
            };
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"SELECT [Blog_Id]
      ,[Blog_Title]
      ,[Blog_Author]
      ,[Blog_Content]
  FROM [dbo].[Tbl_Blog] WHERE Blog_Id = @Blog_Id";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Blog_Id", id);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine($"Blog Id => {dr["Blog_Id"]}");
                    Console.WriteLine($"Blog Author => {dr["Blog_Author"]}");
                    Console.WriteLine($"Blog Title => {dr["Blog_Title"]}");
                    Console.WriteLine($"Blog Content => {dr["Blog_Content"]}");
                    Console.WriteLine("- - - - - - - - - - - - - - -  - - - - - \n");
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }

        private void Create(string author, string title, string content)
        {
            //connect to server
            SqlConnectionStringBuilder sqlStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "KABUKIOS",
                InitialCatalog = "POSDotNetCore01",
                UserID = "sa",
                Password = "sqlconfig",
            };
            SqlConnection sqlConnection = new SqlConnection(sqlStringBuilder.ConnectionString);
            sqlConnection.Open();

            //run a command
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([Blog_Title]
           ,[Blog_Author]
           ,[Blog_Content])
     VALUES
           (@Blog_Title
           ,@Blog_Author
           ,@Blog_Content)";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Blog_Title", title);
            sqlCommand.Parameters.AddWithValue("@Blog_Author", author);
            sqlCommand.Parameters.AddWithValue("@Blog_Content", content);
            int result =  sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result > 0 ? "Creating Successful." : "Creating Failed";

            Console.WriteLine(message);

        }

        private void Delete(int id)
        {
            //connect to server
            SqlConnectionStringBuilder sqlStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "KABUKIOS",
                InitialCatalog = "POSDotNetCore01",
                UserID = "sa",
                Password = "sqlconfig",
            };
            SqlConnection sqlConnection = new SqlConnection(sqlStringBuilder.ConnectionString);
            sqlConnection.Open();

            //run a command
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
           WHERE Blog_Id = @Blog_Id";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Blog_Id", id);
           
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed";

            Console.WriteLine(message);

        }
    }

}

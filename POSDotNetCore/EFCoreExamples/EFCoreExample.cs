using POSDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSDotNetCore.EFCoreExamples
{
    public class EFCoreExample
    {
        private readonly AppDbContext _db = new AppDbContext();
        private object db;

        public void Read()
        {
            
            List<BlogDataModel> lst =  _db.Blogs.ToList();

            foreach(BlogDataModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogContent + "\n" );
            }
        }

        public void Edit(int id)
        {
            var item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data found");
                return;
            }
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogContent);
        }
        public void Create (string author, string title, string content)
        {
            BlogDataModel blog = new BlogDataModel()
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content,
            };

            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Creating Successful." : "Creating Failed.";
            Console.WriteLine(message);
        }
        public void Update (int id, string author, string title, string content)
        {
            var item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if(item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            item.BlogAuthor = author;
            item.BlogTitle = title;
            item.BlogContent = content;

            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            var item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            _db.Blogs.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }
}

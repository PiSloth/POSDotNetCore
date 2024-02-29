using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using POSDotNetCore.WebApi.Models;


namespace POSDotNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BlogController()
        {
            _db = new AppDbContext();
        }
        
        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogDataModel> lst = _db.Blogs.ToList();
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogDataModel blog) {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Creation Successful." : "Creation Failed.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogDataModel blog)
        {
            BlogDataModel item = _db.Blogs.FirstOrDefault(x => x.BlogId == id)!;
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating Successful." : "Updaing Failed.";
           return Ok(message);
        }
        

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
           BlogDataModel item = _db.Blogs.FirstOrDefault(x => x.BlogId == id)!;
            if (item is null)
            {
                return NotFound("No data Found.");
            }
            _db.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed";
            return Ok(message);
        }

    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using POSDotNetCore.MvcApp.Models;
using System.Diagnostics;

namespace POSDotNetCore.MvcApp.Controllers
{
	public class BlogController : Controller
	{
		private readonly AppDbContextOnMac _db;

		public BlogController () {
			_db = new AppDbContextOnMac();
			}

		[ActionName("Index")]
		public IActionResult BlogIndex()
		{
           List<BlogDataModelOnMac> lst = _db.Blogs.ToList();
            return View("BlogIndex" , lst);
		}

		[ActionName("Edit")]
		public IActionResult BlogEdit(int id)
		{
			BlogDataModelOnMac item = _db.Blogs.FirstOrDefault(x => x.BlogId == id)!;
			if(item is null)
			{
				return Redirect("/Blog");
			}else
			{
				return View("BlogEdit", item);
			}
		}

		[ActionName("Create")]
		public IActionResult BlogCreate()
		{
			return View("BlogCreate");
		}

		[HttpPost]
		[ActionName("Save")]
		public IActionResult BlogSave(BlogDataModelOnMac blog)
		{
			_db.Add(blog);
			_db.SaveChanges();
			return Redirect("/Blog");
		}

		[HttpPost]
		[ActionName("Update")]
		public IActionResult BlogUpdate(int id, BlogDataModelOnMac blog)
		{
			BlogDataModelOnMac item = _db.Blogs.FirstOrDefault(x => x.BlogId == id)!;
			if (item is null)
			{
				return Redirect("/Blog");
			}else
			{
				item.BlogAuthor = blog.BlogAuthor;
				item.BlogTitle = blog.BlogTitle;
				item.BlogContent = blog.BlogContent;
				_db.SaveChanges();

				return Redirect("/Blog");
			}
		}

		[ActionName("Delete")]
		public IActionResult BlogDelete(int id)
		{
			BlogDataModelOnMac item = _db.Blogs.FirstOrDefault(x => x.BlogId == id)!;
			if (item is null)
			{
				return Redirect("/Blog");
			}else
			{
				_db.Remove(item);
				_db.SaveChanges();

				return Redirect("/Blog");
			}
		}
    }
}


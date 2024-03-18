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
    }
}


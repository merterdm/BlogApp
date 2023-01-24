using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
		private readonly IBlogManager blogManager;

		public BlogController(IBlogManager blogManager)
        {
			this.blogManager = blogManager;
		}
        public async Task<IActionResult> Index()
        {
            var result = await blogManager.FindAllIncludeAsync(null,p=>p.Category);
            return View(result.ToList());
        }
        public async Task<IActionResult> BlogDetails(int id)
        {
            var result = await blogManager.FindAllIncludeAsync(p=>p.ID == id,p=>p.Category);          
            return View(result.ToList());
        }
    }
}

using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm = new WriterManager();
        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(Writer writer)
		{
			writer.Status = true;
			writer.WriterImage = "test";
			writer.WriterAbout = "Test123";

			wm.CreateAsync(writer);
			return RedirectToAction("Index","Blog");
		}
	}
}

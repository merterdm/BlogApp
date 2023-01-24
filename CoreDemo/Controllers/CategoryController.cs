using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager categoryManager;
       

        public CategoryController(ICategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;

        }
        
        public async Task<IActionResult> Index()
        {
            var result =await categoryManager.FindAllAsnyc();    
            return View(result);
        }
        //[HttpGet]
        //public async Task<IActionResult> CreateCategory(Category category)
        //{
        //    var result = await categoryManager.CreateAsync(category);
        //    return View(result);
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreateCategory(Category category)
        //{

        //    Category cat = new Category {Blogs=category.Blogs,
        //    };
        //    var result = await categoryManager.CreateAsync(cat);
        //    return View(result);
        //}

    }
}

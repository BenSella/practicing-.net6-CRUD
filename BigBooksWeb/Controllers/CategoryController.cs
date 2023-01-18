using BigBooksWeb.Data;
using BigBooksWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BigBooksWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objectCategoryList = this._db.Categories;    
            return View(objectCategoryList);
        }
    }
}

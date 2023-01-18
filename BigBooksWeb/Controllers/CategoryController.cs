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
        //Get method
        public IActionResult Index()
        {
            IEnumerable<Category> objectCategoryList = this._db.Categories;    
            return View(objectCategoryList);
        }
        //Get method
        public IActionResult Create()
        {
          return View();
        }
        //Post method
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name.Equals(obj.DisplayOrder))
                {
                    ModelState.AddModelError("Name", "Name and Display Order cant be the same");
                }
            if (ModelState.IsValid)
            {
                this._db.Categories.Add(obj);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}

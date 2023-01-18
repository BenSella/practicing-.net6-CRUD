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
        //Get method (Update)
        public IActionResult Edit(int? id)
        {
            if(id == null||id==0)
            {
                return NotFound();
            }
            var categoryFromDb = this._db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //Post method (Update)
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name.Equals(obj.DisplayOrder))
            {
                ModelState.AddModelError("Name", "Name and Display Order cant be the same");
            }
            if (ModelState.IsValid)
            {
                this._db.Categories.Update(obj);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get method (Delete)
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = this._db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //Post method (Delete)
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = this._db.Categories.Find(id);
            if(obj== null)
            {
               return NotFound();
            }
            this._db.Categories.Remove(obj);
            this._db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}

using BulkyWeb.Data;
using Microsoft.AspNetCore.Mvc;
using BulkyWeb.Models;
namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.Display.ToString())
            {
                ModelState.AddModelError("Name", "Name Cannot Be Same As Display");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "New Category Created";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET
        public IActionResult Edit(int ? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            if(category==null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.Display.ToString())
            {
                ModelState.AddModelError("Name", "Name Cannot Be Same As Display");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int?id)
        {

            if (   id ==null)
            {
                return NotFound();
            }

               var category = _db.Categories.Find(id);
               _db.Categories.Remove(category);
               _db.SaveChanges();
               return RedirectToAction("Index");
           
        }
    }
}

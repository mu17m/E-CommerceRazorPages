using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Database;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly cls_Database _db;
        public CategoryController(cls_Database db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Category name cannot exactly match DisplayOrder");
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["Success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0)            
                return BadRequest($"Category with Id {Id} is not valid");  
            
            Category? categoryDB = _db.Categories.Find(Id);
            if (categoryDB == null) 
                return NotFound($"Category with Id {Id} is not found");

            return View(categoryDB);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Category name cannot exactly match DisplayOrder");
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["Success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
                return BadRequest($"Category with Id {Id} is not valid");

            Category? categoryDB = _db.Categories.Find(Id);
            if (categoryDB == null)
                return NotFound($"Category with Id {Id} is not found");

            return View(categoryDB);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            if (Id == null || Id == 0)
                return BadRequest($"Category with Id {Id} is not valid");

            Category? category = _db.Categories.Find(Id);
            if (category == null)
                return NotFound($"Category with Id {Id} is not found");

            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

using BulkyWeb.Database;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly cls_Database _db;
        [BindProperty]
        public Category? Category { get; set; }
        public DeleteModel(cls_Database db)
        {
            _db = db;
        }

        public IActionResult OnGet(int? Id)
        {
            if(Id == null || Id == 0)            
                return BadRequest($"Category with Id {Id} is not valid"); 
            Category = _db.Categories.Find(Id);
            if(Category == null)            
                return NotFound($"Category with Id {Id} is not found");
            return Page();
        }

        public IActionResult OnPost()
        {
            if(Category == null)
                return NotFound("Category is not found");
            _db.Categories.Remove(Category);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
    }
}

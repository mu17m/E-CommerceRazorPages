using BulkyWeb.Database;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly cls_Database _db;
        [BindProperty]
        public Category? Category { get; set; }
        public EditModel(cls_Database db)
        {
            _db = db;
        }

        public IActionResult OnGet(int? Id)
        {
            if (Id == null || Id == 0)
                return BadRequest($"Category with id {Id} is not valid");
            Category = _db.Categories.Find(Id);
            if (Category == null)
                return NotFound($"Category with id {Id} not found");
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid && Category == null)
                return Page();
            _db.Categories.Update(Category);
            _db.SaveChanges();
            TempData["success"] = "Category edited successfully";
            return RedirectToPage("Index");
        }
    }
}

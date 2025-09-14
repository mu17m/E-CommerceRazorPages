using BulkyWeb.Database;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly cls_Database _db;
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(cls_Database db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (Category == null)
                return BadRequest($"Category is not valid!");
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully!";
            return RedirectToPage("Index");
        }
    }
}

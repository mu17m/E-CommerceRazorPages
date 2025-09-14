using BulkyWeb.Database;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly cls_Database _db;
        public List<Category> Categories { get; set; }
        public IndexModel(cls_Database db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Categories = _db.Categories.ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PresentationLayer.Models;

namespace PresentationLayer.Database
{
    public class cls_Database : DbContext
    {
        public cls_Database(DbContextOptions<cls_Database> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

        }
}

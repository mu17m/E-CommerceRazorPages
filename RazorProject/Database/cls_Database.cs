using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BulkyWeb.Database
{
    public class cls_Database : DbContext
    {
        public cls_Database(DbContextOptions<cls_Database> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        // Seed Data for Category
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );
        }

    }
}

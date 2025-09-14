using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Display Order should be in range 1-100")]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

    }
}

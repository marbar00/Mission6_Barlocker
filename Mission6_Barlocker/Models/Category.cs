using System.ComponentModel.DataAnnotations;

namespace Mission6_Barlocker.Models
{
    public class Category
    {
        [Key]
        [Required]
        public required int CategoryId { get; set; }
        [Required]
        public required string CategoryName { get; set; }
    }
}

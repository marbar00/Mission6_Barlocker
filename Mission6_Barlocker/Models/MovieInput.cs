using System.ComponentModel.DataAnnotations;

namespace Mission6_Barlocker.Models
{
    public class MovieInput
    {
        [Key]
        [Required]
        public int MovieInputID { get; set; }
        public required string Category { get; set; }
        public required string SubCategory { get; set; }
        public required string Title { get; set; }
        public required int Year { get; set; }
        public required string Director { get; set; }
        public required string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}

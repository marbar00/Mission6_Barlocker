using System.ComponentModel.DataAnnotations;

namespace Mission6_Barlocker.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public required int MovieInputID { get; set; }
        public required int CategoryId { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public required int Year { get; set; }

        public required string Director { get; set; }
        public required string Rating { get; set; }
        [Required]
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        [Required]
        public required int CopiedToPlex { get; set; }
        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}

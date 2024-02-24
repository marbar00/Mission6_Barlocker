using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Barlocker.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "Please enter a movie title.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the year the movie can out.")]
        [Range(1888, int.MaxValue, ErrorMessage = "Please enter a year during or after 1888.")]
        public int Year { get; set; }

        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "Please choose if the movie was edited or not.")]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "Please choose if the movie was added to Plex or not.")]
        public bool CopiedToPlex { get; set; }
        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}

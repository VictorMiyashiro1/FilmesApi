using System.ComponentModel.DataAnnotations;

namespace Filmes.Api.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Genre { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public string? ImageUrl { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

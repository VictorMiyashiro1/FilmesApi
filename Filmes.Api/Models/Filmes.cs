using System.ComponentModel.DataAnnotations;

namespace Filmes.Api.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Genre { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        [Url, StringLength(1000)]
        public string? ImageUrl { get; set; }

        [Range(0, int.MaxValue)]
        public int Likes { get; set; }

        [Range(0, int.MaxValue)]
        public int Dislikes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

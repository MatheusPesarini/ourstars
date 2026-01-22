using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ourstars_back.Models
{
    public enum ReviewType
    {
        Movie,
        Game,
        Serie,
        Music
    }

    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public ReviewType Type { get; set; }

        [Range(0, 5)]
        public float Rating { get; set; }
        public string Content { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "jsonb")]
        public string? ExtraData { get; set; }

        [Required]
        public string OwnerId { get; set; } = string.Empty;
        public string? TaggedUserId { get; set; }
    }
}

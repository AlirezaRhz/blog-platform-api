using System.ComponentModel.DataAnnotations;

namespace BlogPlatform.Api.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required, MinLength(1)]
        public List<string> Tags { get; set; } = new List<string>();

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}

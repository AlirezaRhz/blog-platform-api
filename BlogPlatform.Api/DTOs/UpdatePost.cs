using System.ComponentModel.DataAnnotations;

namespace BlogPlatform.Api.DTOs
{
    public class UpdatePost
    {
        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required, MinLength(1)]
        public List<string> Tags { get; set; } = new List<string>();
    }
}

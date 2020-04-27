using System;
using System.ComponentModel.DataAnnotations;

namespace CsharpExam.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Must be at least {1} characters")]
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int IdeaId { get; set; }
        public int UserId { get; set; }
        public User Author { get; set; }
    }
}
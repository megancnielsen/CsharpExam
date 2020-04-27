using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CsharpExam.Models
{
    public class Idea
    {
        [Key]
        public int IdeaId { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = " Must be at least {1} characters!")]
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public string Alias { get; set; }
        // Navigation Property
        public User SubittedBy { get; set; }
        public List<Like> Likes { get; set; }

        public Idea (string alias, string body)
        {
            Alias = alias;
            Body = body;
        }

        public Idea ()
        {
            
        }
    }
}
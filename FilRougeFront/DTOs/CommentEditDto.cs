using FilRougeCore.Models;
using System.ComponentModel.DataAnnotations;

namespace FilRougeFront.DTOs
{
    public class CommentEditDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int SessionId { get; set; }

        [Required]
        public string? Message { get; set; }
        [RangeAttribute(0, 5)]
        public int Rating { get; set; }
    }
}

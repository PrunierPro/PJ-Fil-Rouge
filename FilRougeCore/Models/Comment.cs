using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeCore.Models
{
    public class Comment
    {
        //Keys
        [Key]
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public Session Session { get; set; }
        [Required]
        public int SessionId { get; set; }

        [Required]
        public string? Message { get; set; }
        [RangeAttribute(0, 5)]
        public int Rating { get; set; }
    }
}

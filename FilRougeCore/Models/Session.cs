using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeCore.Models
{
    internal class Session
    {
        //Keys
        public int Id { get; set; }
        [Required]
        public Room Room { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public List<User> Users { get; set; } = new List<User>();
        [Required]
        public List<int> UserIds { get; set; } = new List<int>();
        [Required]
        public List<Comment> Comments { get; set; } = new List<Comment>();
        [Required]
        public List<int> CommentIds { get; set; } = new List<int>();

        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    }
}

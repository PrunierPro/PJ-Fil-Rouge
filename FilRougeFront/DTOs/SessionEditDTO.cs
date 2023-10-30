using FilRougeCore.Models;
using System.ComponentModel.DataAnnotations;

namespace FilRougeFront.DTOs
{
    public class SessionEditDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RoomId { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    }
}

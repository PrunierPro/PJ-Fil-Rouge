using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeCore.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
        [Required]
        public string? Name { get; set; }
        public string? Location { get; set; }
        public List<Activity> Activities { get; set; } = new List<Activity>();
        public string? ImageURL { get; set; }

    }
}

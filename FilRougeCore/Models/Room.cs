using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeCore.Models
{
    internal class Room
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public List<string> Activities { get; set; } = new List<string>();
        [Required]
        public Dictionary<DateTime, DateTime> Schedule { get; set; } = new Dictionary<DateTime, DateTime>();
    }
}

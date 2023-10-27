using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeCore.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        [AllowNull]
        public Room Room { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        [RegularExpression("^(Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday)$")]
        public string? Day { get; set; }
        [Required]
        public DateTime OpenTime { get; set; }
        [Required]
        public DateTime CloseTime { get; set; }
    }
}

using FilRougeCore.Models;
using System.ComponentModel.DataAnnotations;
using ActivityCore = FilRougeCore.Models.Activity;

namespace FilRougeFront.DTOs
{
    public class RoomEditDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le Nom est requis.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "La localisation est requise.")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Les horaires sont requis.")]
        public List<Schedule> Schedules { get; set; }

        [Required(ErrorMessage = "Les activités sont requises.")]
        public List<ActivityCore> Activities { get; set; }
    }
}


using FilRougeCore.Models;
using System.ComponentModel.DataAnnotations;


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

        [Required(ErrorMessage = "Le lien vers l'image est requis.")]
        public string? ImageURL { get; set; }

        public List<Schedule>? Schedules { get; set; }

        public List<Activity>? Activities { get; set; }
    }
}


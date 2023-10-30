using FilRougeCore.Models;
using FilRougeFront.DTOs;
using FilRougeFront.Services;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace FilRougeFront.Pages
{
    public partial class Rooms
    {
#nullable disable
        [Inject]
        public IRoomService roomService { get; set; }
#nullable enable
        private string? LoadingMessage { get; set; }
        private bool IsAdminMode { get; set; }      
        private RoomEditDTO? RoomToEdit { get; set; } = null;
        private List<Room> sallesDeSport { get; set; } = new();
        private EditionModes EditionMode { get; set; }
        private enum EditionModes
        {
            Post,
            Put
        }


        private User User { get; set; }
        protected override async Task OnInitializedAsync()
        {
            LoadingMessage = "Récupération des Salle !";
            sallesDeSport = await roomService.GetAll();
            LoadingMessage = "";
            User = await _localStorage.GetItemAsync<User>("user");
            IsAdminMode = User is not null ? User.IsAdmin : false;
        }

        private void EditRoom(Room room)
        {
            RoomToEdit = new RoomEditDTO()
            {
                Id = room.Id,
                Name = room.Name,
                Location = room.Location,
                ImageURL = Regex.Split(room.ImageURL!, @"https:\/\/localhost:\d{1,4}").Last(),
                Activities = room.Activities,
                Schedules = room.Schedules
            };
            EditionMode = EditionModes.Put;
        }

        private void AddRoom()
        {
            RoomToEdit = new RoomEditDTO();
            EditionMode = EditionModes.Post;

        }
        private async Task DeleteRoom(int id)
        {
            sallesDeSport.RemoveAll(p => p.Id == id);
            await roomService.Delete(id);
        }


        private async Task SubmitRoom()
        {
            switch (EditionMode)
            {
                case EditionModes.Post:
                    var room2 = new Room()
                    {
                        Name = RoomToEdit!.Name,
                        Location = RoomToEdit.Location,
                        ImageURL = Regex.Split(RoomToEdit.ImageURL!, @"https:\/\/localhost:\d{1,4}").Last(),
                        Activities = RoomToEdit.Activities,
                        Schedules = RoomToEdit.Schedules

                    };
                    sallesDeSport.Add(room2);
                    await roomService.Post(room2);
                    break;
                case EditionModes.Put:
                    var room = sallesDeSport.Find(room => room.Id == RoomToEdit!.Id)!;
                    room.Name = RoomToEdit!.Name;
                    room.Location = RoomToEdit!.Location;
                    room.ImageURL = Regex.Split(RoomToEdit.ImageURL!, @"https:\/\/localhost:\d{1,4}").Last();
                    room.Activities = RoomToEdit!.Activities; 
                    room.Schedules = RoomToEdit!.Schedules; 

                    await roomService.Put(room);
                    break;
                default:
                    break;
            }

            // Réinitialise RoomToEdit après l'opération
            RoomToEdit = null;
        }

        private async void LogOut()
        {
            await _localStorage.RemoveItemAsync("user");
            Navigator.NavigateTo(Navigator.Uri, forceLoad: true); //actualiser après déconnexion
        }
    }
}





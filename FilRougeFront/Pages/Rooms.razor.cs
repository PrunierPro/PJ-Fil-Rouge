using FilRougeCore.Models;
using FilRougeFront.DTOs;
using FilRougeFront.Services;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;

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
        private FiltresRecherche filtresRecherche = new FiltresRecherche();
        private RoomEditDTO? RoomToEdit { get; set; } = null;
        private List<Room> sallesDeSport;
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
                    await roomService.Post(RoomToEdit);
                    break;
                case EditionModes.Put:
                    await roomService.Put(RoomToEdit);
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
    //private async Task RechercherSallesDeSport()
    //{
    //    //  appel à votre API pour rechercher les salles de sport
    //    // Utilisez l'objet filtresRecherche pour envoyer les critères de recherche
    //     sallesDeSport = await Http.PostAsJsonAsync<List<Room>>("api/recherchesallesdesport", filtresRecherche);

    //}

    public class FiltresRecherche
    {
        public string Location { get; set; }

        // Ajoutez ici d'autres critères de recherche (types d'activités, horaires, etc.)
    }



}





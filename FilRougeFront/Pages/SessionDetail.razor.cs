using FilRougeCore.Models;
using FilRougeFront.DTOs;
using FilRougeFront.Services;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace FilRougeFront.Pages
{
    public partial class SessionDetail
    {
        [Parameter]
        public int sessionId { get; set; }

        private Session? Model { get; set; }

        private User? User { get; set; }

        private CommentEditDTO CommentEdit { get; set; }
        private EditionModes EditionMode { get; set; }
        private enum EditionModes
        {
            Post,
            Put
        }

        [Inject]
        public SessionService sessionService { get; set; }
        [Inject]
        public UserService userService { get; set; }
        [Inject]
        public CommentService commentService { get; set; }

        public string LoadingMessage { get; set; } = "Chargement...";

        protected override async Task OnInitializedAsync()
        {
            await LoadModel();
            User = await _localStorage.GetItemAsync<User>("user");
            LoadingMessage = "";
        }

        private async Task<List<User>> GetTrueUsers(List<User> FakeUsers)
        {
            List<User> res = new List<User>();
            foreach (User u in FakeUsers)
            {
                res.Add(await userService.Get(u.Id));
            }
            return res;
        }

        private async Task<List<Comment>> GetTrueComments(List<Comment> FakeComments)
        {
            List<Comment> res = new List<Comment>();
            foreach (Comment c in FakeComments)
            {
                res.Add(await commentService.Get(c.Id));
            }
            return res;
        }

        private void AddComment()
        {
            CommentEdit = new CommentEditDTO()
            {
                UserId = User.Id,
                SessionId = Model.Id
            };
            EditionMode = EditionModes.Post;
        }

        private async Task SubmitComment()
        {
            switch (EditionMode)
            {
                case EditionModes.Post:
                    var comment = new Comment()
                    {
                        UserId = CommentEdit.UserId,
                        SessionId = CommentEdit.SessionId,
                        Rating = CommentEdit.Rating,
                        Message = CommentEdit.Message

                    };
                    await commentService.Post(comment);
                    break;
                case EditionModes.Put:
                    var comment2 = Model.Comments.Find(com => com.Id == CommentEdit.Id);
                    comment2.Rating = CommentEdit.Rating;
                    comment2.Message = CommentEdit.Message;
                    await commentService.Put(comment2);
                    break;
                default:
                    break;
            }
            await LoadModel();
            StateHasChanged();
        }

        private async Task DeleteComment(int id)
        {
            Model.Comments.RemoveAll(c => c.Id == id);
            await commentService.Delete(id);
        }
        private async Task LoadModel()
        {
            Model = await sessionService.Get(sessionId);
            Model.Users = await GetTrueUsers(Model.Users);
            Model.Comments = await GetTrueComments(Model.Comments);
        }
    }


}

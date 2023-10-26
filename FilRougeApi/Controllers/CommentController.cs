using FilRougeApi.Helpers;
using FilRougeApi.Repositories;
using FilRougeCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilRougeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IRepository<Comment> _repository;

        public CommentController(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _repository.GetById(id);

            if (comment is null) return NotFound(new { Message = "There is no comment with this id" });
            return Ok(comment);
        }

        [HttpGet("session/{session}")]
        public async Task<IActionResult> GetBySession(int sessionId)
        {
            return Ok(await _repository.GetAll(c => c.SessionId == sessionId));
        }

        [HttpPost]
        [Authorize(Roles = Constants.RoleUser)]
        public async Task<IActionResult> Add([FromBody] Comment comment)
        {
            var commentId = await _repository.Add(comment);

            if (commentId > 1)
                return CreatedAtAction(nameof(GetAll), "comment added");

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Constants.RoleUser)]
        public async Task<IActionResult> Update(int id, [FromBody] Comment comment)
        {
            var aniTemp = await _repository.GetById(id);
            if (aniTemp == null)
                return BadRequest("comment not found");

            comment.Id = id;
            if (await _repository.Update(comment))
                return Ok("comment Updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.RoleUser)]
        public async Task<IActionResult> Remove(int id)
        {
            var aniTemp = await _repository.GetById(id);
            if (aniTemp == null)
                return BadRequest("comment not found");

            if (await _repository.Delete(id))
                return Ok("comment Deleted !");

            return BadRequest("Something went wrong...");
        }
    }
}

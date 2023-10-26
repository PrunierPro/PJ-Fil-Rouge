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
    public class SessionController : ControllerBase
    {
        private readonly IRepository<Session> _repository;

        public SessionController(IRepository<Session> repository)
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
            var session = await _repository.GetById(id);

            if (session is null) return NotFound(new { Message = "There is no session with this id" });
            return Ok(session);
        }

        [HttpGet("room/{room}")]
        public async Task<IActionResult> GetByRoom(int roomId)
        {
            return Ok(await _repository.GetAll(s => s.RoomId == roomId));
        }

        [HttpPost]
        [Authorize(Roles = Constants.RoleUser)]
        public async Task<IActionResult> Add([FromBody] Session session)
        {
            var sessionId = await _repository.Add(session);

            if (sessionId > 1)
                return CreatedAtAction(nameof(GetAll), "session added");

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Constants.RoleUser)]
        public async Task<IActionResult> Update(int id, [FromBody] Session session)
        {
            var aniTemp = await _repository.GetById(id);
            if (aniTemp == null)
                return BadRequest("session not found");

            session.Id = id;
            if (await _repository.Update(session))
                return Ok("session Updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.RoleUser)]
        public async Task<IActionResult> Remove(int id)
        {
            var aniTemp = await _repository.GetById(id);
            if (aniTemp == null)
                return BadRequest("session not found");

            if (await _repository.Delete(id))
                return Ok("session Deleted !");

            return BadRequest("Something went wrong...");
        }
    }
}

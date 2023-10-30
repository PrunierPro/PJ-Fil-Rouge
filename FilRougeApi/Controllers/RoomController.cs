using FilRougeApi.Repositories;
using FilRougeCore.Models;
using FilRougeApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilRougeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRepository<Room> _repository;

        public RoomController(IRepository<Room> repository)
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
            var room = await _repository.GetById(id);

            if (room is null) return NotFound(new { Message = "There is no room with this id" });
            return Ok(room);
        }

        /*[HttpGet("activity/{activity}")]
        public async Task<IActionResult> GetByActivity(string activity)
        {
            return Ok(await _repository.GetAll(r => r.Activities.FindAll(a => a.Name == activity).Count > 0));
        }*/

        [HttpGet("location/{location}")]
        public async Task<IActionResult> GetByLocation(string location)
        {
            return Ok(await _repository.GetAll(r => r.Location == location));
        }

        [HttpPost]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Add([FromBody] Room room)
        {
            var roomId = await _repository.Add(room);

            if (roomId > 0)
                return CreatedAtAction(nameof(GetAll), "room added");

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Update(int id, [FromBody] Room room)
        {
            var aniTemp = await _repository.GetById(id);
            if (aniTemp == null)
                return BadRequest("room not found");

            room.Id = id;
            if (await _repository.Update(room))
                return Ok("room Updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Remove(int id)
        {
            var aniTemp = await _repository.GetById(id);
            if (aniTemp == null)
                return BadRequest("room not found");

            if (await _repository.Delete(id))
                return Ok("room Deleted !");

            return BadRequest("Something went wrong...");
        }
    }
}

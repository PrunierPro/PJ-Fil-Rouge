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
    public class ScheduleController : ControllerBase
    {
        private readonly IRepository<Schedule> _repository;

        public ScheduleController(IRepository<Schedule> repository)
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
            var schedule = await _repository.GetById(id);

            if (schedule is null) return NotFound(new { Message = "There is no schedule with this id" });
            return Ok(schedule);
        }

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetByRoom(int roomId)
        {
            return Ok(await _repository.GetAll(s => s.RoomId == roomId));
        }

        [HttpGet("day/{day}")]
        public async Task<IActionResult> GetByDay(string day)
        {
            return Ok(await _repository.GetAll(s => s.Day == day));
        }

        [HttpPost]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Add([FromBody] Schedule schedule)
        {
            var scheduleId = await _repository.Add(schedule);

            if (scheduleId > 1)
                return CreatedAtAction(nameof(GetAll), "schedule added");

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Update(int id, [FromBody] Schedule schedule)
        {
            var aniTemp = await _repository.GetById(id);
            if (aniTemp == null)
                return BadRequest("schedule not found");

            schedule.Id = id;
            if (await _repository.Update(schedule))
                return Ok("schedule Updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Remove(int id)
        {
            var aniTemp = await _repository.GetById(id);
            if (aniTemp == null)
                return BadRequest("schedule not found");

            if (await _repository.Delete(id))
                return Ok("schedule Deleted !");

            return BadRequest("Something went wrong...");
        }
    }
}

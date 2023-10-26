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
    public class ActivityController : ControllerBase
    {
        private readonly IRepository<Activity> _repository;

        public ActivityController(IRepository<Activity> repository)
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
            var activity = await _repository.GetById(id);

            if (activity is null) return NotFound(new { Message = "There is no activity with this id" });
            return Ok(activity);
        }

        [HttpPost]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Add([FromBody] Activity activity)
        {
            var activityId = await _repository.Add(activity);

            if (activityId > 1)
                return CreatedAtAction(nameof(GetAll), "activity added");

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Update(int id, [FromBody] Activity activity)
        {
            var aniTemp = await _repository.GetById(id);
            if (aniTemp == null)
                return BadRequest("activity not found");

            activity.Id = id;
            if (await _repository.Update(activity))
                return Ok("activity Updated !");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Remove(int id)
        {
            var aniTemp = await _repository.GetById(id);
            if (aniTemp == null)
                return BadRequest("activity not found");

            if (await _repository.Delete(id))
                return Ok("activity Deleted !");

            return BadRequest("Something went wrong...");
        }
    }
}

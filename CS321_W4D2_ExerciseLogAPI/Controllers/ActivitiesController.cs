using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W4D2_ExerciseLogAPI.ApiModels;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W4D2_ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }


        // GET: api/<ActivitiesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var activityModels = _activityService.GetAll().ToApiModels();

            return Ok(activityModels);
        }

        // GET api/<ActivitiesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var activity = _activityService.Get(id);

            if (activity == null) return NotFound();

            return Ok(activity.ToApiModel());
        }

        // POST api/<ActivitiesController>
        [HttpPost]
        public IActionResult Post([FromBody] ActivityModel newActivity)
        {
            try
            {
                _activityService.Add(newActivity.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddActivity", ex.GetBaseException().Message);

                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newActivity.Id }, newActivity);
        }

        // PUT api/<ActivitiesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActivityModel updatedActivity)
        {
            var activity = _activityService.Update(updatedActivity.ToDomainModel());

            if (activity == null) return NotFound();

            return Ok(activity.ToApiModel());
        }

        // DELETE api/<ActivitiesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var activity = _activityService.Get(id);

            if (activity == null) return NotFound();

            _activityService.Remove(activity);

            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

    
    
        [HttpGet]
        [ProducesResponseType(typeof(Task<ActionResult<IEnumerable<Activity>>>), 200)]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities() => await Mediator.Send(new List.Query());
    
    
    
        [HttpGet]
        [ProducesResponseType(typeof(Task<ActionResult<Activity>>), 200)]
        [ProducesResponseType(404)]
        [Route("[action]/Id/{id}")]
        public async Task<ActionResult<Activity>> GetActivityById([FromRoute] Guid id) 
            => await Mediator.Send(new Details.Query { Id = id });


        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Create([FromBody] Activity activity) => Created(nameof(Created), await Mediator.Send(new Create.Command { Activity = activity}));


        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update([FromBody] Activity activity)
        {
            if(activity.Id == Guid.Empty || activity.Id == default)
            {
                return BadRequest(activity);
            }

            return Ok(await Mediator.Send(new Update.Command { Activity = activity} ));
        } 



        [HttpDelete]
        [ProducesResponseType(200)]
        [Route("[action]/Id/{id}")]
        
        public async Task<IActionResult> Delete([FromRoute] Guid id) => Ok(await Mediator.Send(new Delete.Command { Id = id }));
    
    }
}
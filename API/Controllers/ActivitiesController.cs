
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context = default;
        public ActivitiesController(DataContext context) => (_context) = (context); 



        [HttpGet]
        [ProducesResponseType(typeof(Task<ActionResult<IEnumerable<Activity>>>), 200)]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities() => await _context.Activities.ToListAsync();
    
    
    
    
        [HttpGet]
        [ProducesResponseType(typeof(Task<ActionResult<Activity>>), 200)]
        [ProducesResponseType(404)]
        [Route("[action]/Id/{id}")]
        public async Task<ActionResult<Activity>> GetActivityById([FromRoute] Guid id) 
        {
            Activity activityWithSearchedId = await _context.Activities.FindAsync(id);

            if(activityWithSearchedId is null) 
            {
                return NotFound();
            }

            return activityWithSearchedId;
        }

    
    }
}
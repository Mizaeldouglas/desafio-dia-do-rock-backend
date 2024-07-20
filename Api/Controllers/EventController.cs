using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EventController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/<EventController>
        [HttpGet]
        public async Task<ActionResult<List<EventModel>>> GetAll()
        {
            try
            {
                var events = await _context.Events.ToListAsync();

                return events;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventModel>> GetById(int id)
        {
            try
            {
                var events = await _context.Events.FindAsync(id);

                if (events == null)
                {
                    return NotFound();
                }

                return events;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                
            }
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

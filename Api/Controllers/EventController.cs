using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("event")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly ApiDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public EventController(ApiDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
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


    // POST api/<EventController>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EventModel eventModel)
    {
        try
        {
            // var filePath = Path.Combine(_environment.ContentRootPath, "storage", "image", file.FileName);
            // using (var stream = new FileStream(filePath, FileMode.Create))
            // {
            //     await file.CopyToAsync(stream);
            // }
            // eventModel.Image = filePath;


            await _context.Events.AddAsync(eventModel);
            await _context.SaveChangesAsync();

            return Ok(new { events = eventModel });
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }


    [HttpPost("image-upload/{id}")]
    public async Task<IActionResult> UploadImage(int id, IFormFile file)
    {
        var eventModel = await _context.Events.FindAsync(id);
        if (eventModel == null) return NotFound();

        if (file.Length > 0)
        {
            var filePath = Path.Combine(_environment.ContentRootPath, "storage", "image", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            eventModel.Image = filePath;
            await _context.SaveChangesAsync();
            return Ok(new { path = filePath });
        }

        return BadRequest("Falha ao fazer upload da imagem.");
    }
}
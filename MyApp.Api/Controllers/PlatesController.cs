using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Endpoint protegido – exige token JWT
    public class PlatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var plates = await _context.Plates.ToListAsync();
            return Ok(plates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var plate = await _context.Plates.FindAsync(id);
            if (plate == null)
                return NotFound();
            return Ok(plate);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Plate plate)
        {
            _context.Plates.Add(plate);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = plate.Id }, plate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Plate plate)
        {
            if (id != plate.Id)
                return BadRequest();

            _context.Entry(plate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var plate = await _context.Plates.FindAsync(id);
            if (plate == null)
                return NotFound();

            _context.Plates.Remove(plate);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

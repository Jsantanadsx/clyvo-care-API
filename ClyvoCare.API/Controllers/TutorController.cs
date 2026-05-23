using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClyvoCare.API.Data;
using ClyvoCare.API.Entities;

namespace ClyvoCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TutorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tutor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetAll()
        {
            var tutores = await _context.Tutores.ToListAsync();

            return Ok(tutores);
        }

        // GET: api/tutor/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetById(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);

            if (tutor == null)
                return NotFound();

            return Ok(tutor);
        }

        // POST: api/tutor
        [HttpPost]
        public async Task<ActionResult<Tutor>> Create(Tutor tutor)
        {
            _context.Tutores.Add(tutor);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = tutor.IdTutor },
                tutor
            );
        }

        // PUT: api/tutor/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Tutor tutor)
        {
            if (id != tutor.IdTutor)
                return BadRequest();

            _context.Entry(tutor).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/tutor/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);

            if (tutor == null)
                return NotFound();

            _context.Tutores.Remove(tutor);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
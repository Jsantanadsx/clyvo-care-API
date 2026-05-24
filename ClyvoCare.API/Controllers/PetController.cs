using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClyvoCare.API.Data;
using ClyvoCare.API.Entities;
using ClyvoCare.API.DTOs;

namespace ClyvoCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/pet
        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetResponseDto>>> GetAll(
    int page = 1,
    int pageSize = 10)
        {
            var pets = await _context.Pets
                .Include(p => p.Tutor)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PetResponseDto
                {
                    IdPet = p.IdPet,
                    NomePet = p.NomePet,
                    Especie = p.Especie,
                    Raca = p.Raca,
                    NomeTutor = p.Tutor.NomeTutor
                })
                .ToListAsync();

            return Ok(pets);
        }

        // GET: api/pet/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetById(int id)
        {
            var pet = await _context.Pets
                .Include(p => p.Tutor)
                .FirstOrDefaultAsync(p => p.IdPet == id);

            if (pet == null)
                return NotFound();

            return Ok(pet);
        }

        // GET: api/pet/tutor/1
        [HttpGet("tutor/{idTutor}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetByTutor(int idTutor)
        {
            var pets = await _context.Pets
                .Where(p => p.IdTutor == idTutor)
                .Include(p => p.Tutor)
                .ToListAsync();

            return Ok(pets);
        }

        // GET: api/pet/especie/Cachorro
        [HttpGet("especie/{especie}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetByEspecie(string especie)
        {
            var pets = await _context.Pets
                .Where(p => p.Especie == especie)
                .Include(p => p.Tutor)
                .ToListAsync();

            return Ok(pets);
        }

        // POST: api/pet
        [HttpPost]
        public async Task<ActionResult<Pet>> Create(Pet pet)
        {
            _context.Pets.Add(pet);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = pet.IdPet },
                pet
            );
        }

        // PUT: api/pet/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pet pet)
        {
            if (id != pet.IdPet)
                return BadRequest();

            _context.Entry(pet).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/pet/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
                return NotFound();

            _context.Pets.Remove(pet);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClyvoCare.API.Data;
using ClyvoCare.API.Entities;
using ClyvoCare.API.DTOs;

namespace ClyvoCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsultaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/consulta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultaResponseDto>>> GetAll()
        {
            var consultas = await _context.Consultas
                .Include(c => c.Pet)
                .ThenInclude(p => p.Tutor)
                .Select(c => new ConsultaResponseDto
                {
                    IdConsulta = c.IdConsulta,
                    DataConsulta = c.DataConsulta,
                    NomePet = c.Pet.NomePet,
                    NomeTutor = c.Pet.Tutor.NomeTutor
                })
                .ToListAsync();

            return Ok(consultas);
        }

        // GET: api/consulta/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Consulta>> GetById(int id)
        {
            var consulta = await _context.Consultas
                .Include(c => c.Pet)
                .ThenInclude(p => p.Tutor)
                .FirstOrDefaultAsync(c => c.IdConsulta == id);

            if (consulta == null)
                return NotFound();

            return Ok(consulta);
        }

        // GET: api/consulta/pet/1
        [HttpGet("pet/{idPet}")]
        public async Task<ActionResult<IEnumerable<Consulta>>> GetByPet(int idPet)
        {
            var consultas = await _context.Consultas
                .Where(c => c.IdPet == idPet)
                .Include(c => c.Pet)
                .ThenInclude(p => p.Tutor)
                .ToListAsync();

            return Ok(consultas);
        }

        // GET: api/consulta/status/Finalizada
     //   [HttpGet("status/{status}")]
     //   public async Task<ActionResult<IEnumerable<Consulta>>> GetByStatus(string status)
     //   {
     //       var consultas = await _context.Consultas
     //           .Where(c => c.StatusConsulta == status)
     //           .Include(c => c.Pet)
     //           .ThenInclude(p => p.Tutor)
     //           .ToListAsync();

     //       return Ok(consultas);
     //   }

        // POST: api/consulta
        [HttpPost]
        public async Task<ActionResult<Consulta>> Create(Consulta consulta)
        {
            _context.Consultas.Add(consulta);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = consulta.IdConsulta },
                consulta
            );
        }

        // PUT: api/consulta/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Consulta consulta)
        {
            if (id != consulta.IdConsulta)
                return BadRequest();

            _context.Entry(consulta).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/consulta/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta == null)
                return NotFound();

            _context.Consultas.Remove(consulta);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
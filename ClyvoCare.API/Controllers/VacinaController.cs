using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClyvoCare.API.Data;
using ClyvoCare.API.Entities;

namespace ClyvoCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacinaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VacinaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/vacina
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacina>>> GetAll()
        {
            var vacinas = await _context.Vacinas
                .Include(v => v.Pet)
                .ThenInclude(p => p.Tutor)
                .ToListAsync();

            return Ok(vacinas);
        }

        // GET: api/vacina/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacina>> GetById(int id)
        {
            var vacina = await _context.Vacinas
                .Include(v => v.Pet)
                .ThenInclude(p => p.Tutor)
                .FirstOrDefaultAsync(v => v.IdVacina == id);

            if (vacina == null)
                return NotFound();

            return Ok(vacina);
        }

        // GET: api/vacina/pet/1
        [HttpGet("pet/{idPet}")]
        public async Task<ActionResult<IEnumerable<Vacina>>> GetByPet(int idPet)
        {
            var vacinas = await _context.Vacinas
                .Where(v => v.IdPet == idPet)
                .Include(v => v.Pet)
                .ThenInclude(p => p.Tutor)
                .ToListAsync();

            return Ok(vacinas);
        }

        // GET: api/vacina/vencidas
        [HttpGet("vencidas")]
        public async Task<ActionResult<IEnumerable<Vacina>>> GetVacinasVencidas()
        {
            var vacinas = await _context.Vacinas
                .Where(v => v.ProximaDose < DateTime.Now)
                .Include(v => v.Pet)
                .ThenInclude(p => p.Tutor)
                .ToListAsync();

            return Ok(vacinas);
        }

        // GET: api/vacina/proximas
        [HttpGet("proximas")]
        public async Task<ActionResult<IEnumerable<Vacina>>> GetProximasVacinas()
        {
            var hoje = DateTime.Now;
            var limite = hoje.AddDays(30);

            var vacinas = await _context.Vacinas
                .Where(v => v.ProximaDose >= hoje &&
                            v.ProximaDose <= limite)
                .Include(v => v.Pet)
                .ThenInclude(p => p.Tutor)
                .ToListAsync();

            return Ok(vacinas);
        }

        // POST: api/vacina
        [HttpPost]
        public async Task<ActionResult<Vacina>> Create(Vacina vacina)
        {
            _context.Vacinas.Add(vacina);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = vacina.IdVacina },
                vacina
            );
        }

        // PUT: api/vacina/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Vacina vacina)
        {
            if (id != vacina.IdVacina)
                return BadRequest();

            _context.Entry(vacina).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/vacina/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vacina = await _context.Vacinas.FindAsync(id);

            if (vacina == null)
                return NotFound();

            _context.Vacinas.Remove(vacina);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
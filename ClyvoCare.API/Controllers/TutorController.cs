using Microsoft.AspNetCore.Mvc;
using ClyvoCare.API.Entities;
using ClyvoCare.API.Services;

namespace ClyvoCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutorController : ControllerBase
    {
        private readonly TutorService _service;

        public TutorController(TutorService service)
        {
            _service = service;
        }

        // GET: api/tutor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetAll()
        {
            var tutores = await _service.GetAllAsync();

            return Ok(tutores);
        }

        // GET: api/tutor/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetById(int id)
        {
            var tutor = await _service.GetByIdAsync(id);

            if (tutor == null)
                return NotFound();

            return Ok(tutor);
        }

        // POST: api/tutor
        [HttpPost]
        public async Task<ActionResult<Tutor>> Create(Tutor tutor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novoTutor = await _service.CreateAsync(tutor);

            return CreatedAtAction(
                nameof(GetById),
                new { id = novoTutor.IdTutor },
                novoTutor
            );
        }

        // PUT: api/tutor/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Tutor tutor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var atualizado = await _service.UpdateAsync(id, tutor);

            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/tutor/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _service.DeleteAsync(id);

            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
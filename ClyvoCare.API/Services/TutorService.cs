using Microsoft.EntityFrameworkCore;
using ClyvoCare.API.Data;
using ClyvoCare.API.Entities;

namespace ClyvoCare.API.Services
{
    public class TutorService
    {
        private readonly AppDbContext _context;

        public TutorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tutor>> GetAllAsync()
        {
            return await _context.Tutores.ToListAsync();
        }

        public async Task<Tutor> GetByIdAsync(int id)
        {
            return await _context.Tutores.FindAsync(id);
        }

        public async Task<Tutor> CreateAsync(Tutor tutor)
        {
            _context.Tutores.Add(tutor);

            await _context.SaveChangesAsync();

            return tutor;
        }

        public async Task<bool> UpdateAsync(int id, Tutor tutor)
        {
            var tutorExistente = await _context.Tutores.FindAsync(id);

            if (tutorExistente == null)
                return false;

            tutorExistente.NomeTutor = tutor.NomeTutor;
            tutorExistente.CpfTutor = tutor.CpfTutor;
            tutorExistente.EmailTutor = tutor.EmailTutor;
            tutorExistente.TelefoneTutor = tutor.TelefoneTutor;
            tutorExistente.DataNascimentoTutor = tutor.DataNascimentoTutor;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);

            if (tutor == null)
                return false;

            _context.Tutores.Remove(tutor);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
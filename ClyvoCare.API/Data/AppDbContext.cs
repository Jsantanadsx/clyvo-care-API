using Microsoft.EntityFrameworkCore;
using ClyvoCare.API.Entities;

namespace ClyvoCare.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tutor> Tutores { get; set; }

        public DbSet<Pet> Pets { get; set; }
    }
}
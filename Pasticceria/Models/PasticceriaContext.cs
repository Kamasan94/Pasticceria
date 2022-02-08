using Microsoft.EntityFrameworkCore;

namespace Pasticceria.Models
{
    public class PasticceriaContext:DbContext
    {
        public PasticceriaContext(DbContextOptions<PasticceriaContext> options):base(options)
        { 
        }

        public DbSet<Vetrina> Vetrina { get; set; }
        public DbSet<Dolce> Dolci { get; set;}
        public DbSet<Ricetta> Ricette { get; set; }
        public DbSet<Ingrediente> Ingredienti { get; set; }

  }
}

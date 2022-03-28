using Microsoft.EntityFrameworkCore;
using Pasticceria.Models;

namespace Pasticceria.Models
{
    public class PasticceriaContext:DbContext
    {
        public PasticceriaContext(DbContextOptions<PasticceriaContext> options):base(options)
        { 
        }

        public DbSet<Vetrina>? Vetrina { get; set; }
        public DbSet<Dolce>? Dolci { get; set;}
        public DbSet<Ricetta>? Ricette { get; set; }
        public DbSet<Ingrediente>? Ingredienti { get; set; }
        public DbSet<TabellaTest>? tabellaTest { get; set; }
        public DbSet<Pasticceria.Models.TabellaTest> TabellaTest { get; set; }

  }
}

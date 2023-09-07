using APIPruebaLG.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPruebaLG.Contexto
{
    public class PruebaLGDBContext : DbContext
    {
        public DbSet<departamentos> departamentos { get; set; }
        public DbSet<cargos> cargos { get; set; }
        public DbSet<usuarios> usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<departamentos>()
                .HasKey(c => c.codigoDepartamento);
            modelBuilder.Entity<cargos>()
                .HasKey(c => new { c.codigoCargo, c.codigoDepartamento });
            modelBuilder.Entity<usuarios>()
                .HasKey(c => c.codigoUsuario);
        }

        public PruebaLGDBContext(DbContextOptions<PruebaLGDBContext> options): 
            base(options) 
        {
            
        }
        

    }
}

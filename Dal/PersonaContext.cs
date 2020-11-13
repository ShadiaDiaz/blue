using System;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
        
    public class PersonaContext:DbContext
    {

        public PersonaContext(DbContextOptions options):base(options)
        {
            
        } 
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pago>()
            .HasOne<Persona>().WithMany()
            .HasForeignKey(p => p.PersonaId, p=> p.NombrePersona);

        }
    }
}

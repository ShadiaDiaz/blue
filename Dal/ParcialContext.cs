

namespace Dal
{
     using System;
using Entity;
using Microsoft.EntityFrameworkCore;   
    public class ParcialContext:DbContext
    {

        public ParcialContext(DbContextOptions options):base(options)
        {
            
        } 
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Pago> Pago { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pago>()
            .HasOne<Persona>().WithMany()
            .HasForeignKey(p => p.PersonaId);

        }
    }
}

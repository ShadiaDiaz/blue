
namespace Dal
{
     using System;
using Entity;
using Microsoft.EntityFrameworkCore;   
    public class ParcialesContext:DbContext
    {

        public ParcialesContext(DbContextOptions options):base(options)
        {
            
        } 
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Pago> Pago { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pago>()
            .HasOne<Persona>().WithMany()
            .HasForeignKey(p => p.PersonaId);

        }
    }
}

using System;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
        
    public class PersonaContext:DbContext
    {

        public EmergenciaContext(DbContextOptions options):base(options)
        {
            
        } 
        public DbSet<Persona> Personas { get; set; }
    }
}

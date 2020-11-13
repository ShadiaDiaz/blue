
using System;
using Entity;

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Dal;
namespace Bll
{
  
    public class PersonaService
    {
        private readonly ParcialesContext _context;

        public PersonaService(ParcialesContext context)
        {
            _context = context;
        }

        public GuardarPersonaResponse GuardarPersona(Persona persona)
        {
            try
            {
                var buscarPersona = _context.Persona.Find(persona.Identificacion);
                if(buscarPersona == null)
                {
                    _context.Persona.Add(persona);
                    _context.SaveChanges();
                    return new GuardarPersonaResponse(persona);
                }
                else
                {
                    return new GuardarPersonaResponse("Duplicado");
                }
            }
            catch(Exception e)
            {
                return new GuardarPersonaResponse($"Error en la aplicacion: {e.Message}");
            }
        }

        public ConsultarPersonaResponse ConsultarPersona()
        {
            try
            {
                return new ConsultarPersonaResponse(_context.Persona.ToList());
            }
            catch(Exception e)
            {
                return new ConsultarPersonaResponse($"Error en la aplicacion: {e.Message}");
            }
        }

        public class ConsultarPersonaResponse
        {
            public ConsultarPersonaResponse(List<Persona> personas)
            {
                Error = false;
                Persona = personas;
            }

            public ConsultarPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Persona> Persona { get; set; }
        }
        public class GuardarPersonaResponse
        {
            public GuardarPersonaResponse(Persona persona)
            {
                Persona = persona;
                Error = false;
            }

            public GuardarPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Persona Persona { get; set; }
        }
    }
}
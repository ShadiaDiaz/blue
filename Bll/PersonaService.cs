

namespace Bll
{
    using System;
using Entity;
using Dal;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
    public class PersonaService
    {
        private readonly ParcialContext _context;

        public PersonaService(ParcialContext context)
        {
            _context = context;
        }

        public GuardarPersonaResponse Guardar(Persona persona)
        {
            string mensaje = "";
            try
            {
                if (_context.Personas.Find(persona.Identificacion) == null)
                {
                 
                       _context.Persona.Add(persona);
                       _context.SaveChanges();
                       mensaje = "Persona Registrada Exitosamente";
                        return new GuardarPersonaResponse(mensaje, "Gracias!!");
                    
                   
                }
                else
                {
                    mensaje = "Error: La persona ya se encuentra registrada. ";
                    return new GuardarPersonaResponse(mensaje, "Duplicado");
                }
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error en la aplicacion: {e.Message}", "ErrorAplication");
            }
        }

        public PersonaConsultaResponse Consultar()
        {
            
            try
            {
               
                return new PersonaConsultaResponse(_context.Persona.ToList());
            }
            catch (Exception e)
            {
                return new PersonaConsultaResponse($"Error en la aplicacion: {e.Message}");
            }
        }
        public class GuardarPersonaResponse
        {
            public GuardarPersonaResponse(string mensaje, Persona persona)
            {
                Error = false;
                Mensaje = mensaje;
                Persona = persona;
            }

            public GuardarPersonaResponse(string mensaje, string tipoerror)
            {
                Error = true;
                Mensaje = mensaje;
                TipoRespuesta = tipoerror;
            }
            public bool Error { get; set; }
            public string TipoRespuesta { get; set; }
            public string Mensaje { get; set; }
            public Persona Persona { get; set; }
        }

        public class PersonaConsultaResponse
        {
            public PersonaConsultaResponse(List<Persona> personas)
            {
                Error = false;
                Personas = personas;
            }

            public PersonaConsultaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Persona> Personas { get; set; }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Bll;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Dal;
using parcialSegundo.Modals;
using Microsoft.AspNetCore.Http;

namespace parcialSegundo.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService service;
        public PersonaController(PersonaContext context)
        {
            service = new PersonaService(context);
        }
        // POST: api/Asignatura​s
        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = service.GuardarPersona(persona);
            if(response.Error)
            {
                ModelState.AddModelError("Error al guardar persona", response.Mensaje);
                var detallesproblemas = new ValidationProblemDetails(ModelState);
            if (response.Mensaje == "Duplicado")
            {
                detallesproblemas.Status = StatusCodes.Status400BadRequest;
            }
            else
            {
                detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            }
                return BadRequest(detallesproblemas);
            }
            return Ok(response.Persona);
        }

        //api/Personas
        [HttpGet]
        public ActionResult<PersonaViewModel> Get()
        {
            var response = service.ConsultarPersona();

            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona.Select(a => new PersonaViewModel(a)));
        }



        private Personas MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Persona
            { 
                 TipoDocumento = personaInput.TipoDocumento
                 Identificacion = personaInput.Identificacion;
                 Nombres = personaInput.Nombres;
                 Direccion = personaInput.Direccion;
                 Telefono = personaInput.Telefono;
                 Pais = personaInput.Pais;
                 Departamento = personaInput.Departamento;
                 Ciudad = personaInput.Ciudad;
            };
            return persona;
        }
    }
}
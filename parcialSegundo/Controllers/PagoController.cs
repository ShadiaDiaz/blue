using Microsoft.AspNetCore.Mvc;
using Bll;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Dal;
using parcialSegundo.Models;
using Microsoft.AspNetCore.Http;

namespace parcialSegundo.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly PagoService service;
        public PagoController(ParcialesContext context)
        {
            service = new PagoService(context);
        }
        // POST: api/Pago
        [HttpPost]
        public ActionResult<PagoViewModel> Post(PagoInputModels pagoInput)
        {
            Pago pago = MapearPago(pagoInput);
            var response = service.Guardar(pago);
              if (response.Error)
            {
                ModelState.AddModelError("Error al guardar Pago", response.Mensaje);
                var detallesproblemas = new ValidationProblemDetails(ModelState);

                detallesproblemas.Status = StatusCodes.Status500InternalServerError;
                return BadRequest(detallesproblemas);
            }
            return Ok(response.Pago);
        }

        //api/Pago
        [HttpGet]
        public ActionResult<PagoViewModel> Get()
        {
            var response = service.Consultar();

            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Pago.Select(a => new PagoViewModel(a)));
        }



        private Pago MapearPago(PagoInputModels pagoInput)
        {
            var pago = new Pago
            { 
                     PersonaId = pagoInput.PersonaId,
                     Cod = pagoInput.Cod,
                     TipoPago = pagoInput.TipoPago,
                     FechaPago = pagoInput.FechaPago,
                     ValorPago = pagoInput.ValorPago,
                     ValorIva = pagoInput.ValorIva,
                     PagoTotal = pagoInput.PagoTotal
            };
            return pago;
        }
    }
}
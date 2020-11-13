using System;
using Entity;
using Dal;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bll
{
    public class PagoService
    {
        private readonly PersonaContext _context;

        public PagoService(PersonaContext context)
        {
            _context = context;
        }

        public GuardarPagoResponse Guardar(Pago pago)
        {
            string mensaje = "";
            try
            {
                if (_context.Pago.Find(pago.null) == null)
                {
                         _context.Pago.Add(pago);
                         _context.SaveChanges();
                        mensaje = "Error: Ya se encuentra registrado este pago ";
                        return new GuardarPagoResponse(mensaje, "NO");
                }
                else
                {
                    mensaje = "Error: La persona ya se encuentra registrada. ";
                    return new GuardarPagoResponse(mensaje, "Duplicado");
                }
            }
            catch (Exception e)
            {
                return new GuardarPagoResponse($"Error en la aplicacion: {e.Message}", "ErrorAplication");
            }
        }

        public decimal TotalPagos()
        {
            decimal suma = _context.Pago.Include(p => p.Pago).ToList().Sum(p => p.Pago.TotalPagos);
            return suma;
        }

        

        public PagoConsultaResponse Consultar()
        {
            List<Pago> pagos = new List<Pago>();
            try
            {
                return new PersonaConsultaResponse(pagos);
            }
            catch (Exception e)
            {
                return new PersonaConsultaResponse($"Error en la aplicacion: {e.Message}");
            }
        }
          public BuscarPagoResponse BuscarPago(string numero)
        {
            try
            {
              
                var pagoresponse = solicitudesresponse.Find(s => s.Numero == numero);
                if(pagoresponse != null)
                {
                    pagoresponse.Persona = _context.Personas.Find(pagoresponse.Identificacion);
                
                    return new BuscarSolicitudResponse(pagoresponse);
                }
                else
                {
                    return new BuscarSolicitudResponse($"No existe");
                }
            }
            catch(Exception e)
            {
                return new BuscarSolicitudResponse($"Error: {e.Message}");
            }
        }
        public class GuardarPagoResponse
        {
            public GuardarPagoResponse(string mensaje, Persona persona)
            {
                Error = false;
                Mensaje = mensaje;
                Persona = persona;
            }

            public GuardarPagoResponse(string mensaje, string tipoerror)
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

        public class PagoConsultaResponse
        {
            public PagoConsultaResponse(List<Pago> pagos)
            {
                Error = false;
                Pago = pagos;
            }

            public PagoConsultaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Pago> Pago { get; set; }
        }
    }
}
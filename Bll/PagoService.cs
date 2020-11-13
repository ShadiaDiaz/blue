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
        private readonly ParcialContext _context;
        var Pagoresponse;
        public PagoService(ParcialContext context)
        {
            _context = context;
        }

        public GuardarPagoResponse Guardar(Pago pago)
        {
            string mensaje = "";
            try
            {
                if (_context.Pago.Find(pago.Cod) == null)
                {
                         _context.Pago.Add(pago);
                         _context.SaveChanges();
                        mensaje = "Error: Ya se encuentra registrado este pago ";
                        return new GuardarPagoResponse(mensaje, "NO");
                }
                else
                {
                    mensaje = "Error: El pago ya se encuentra registrada. ";
                    return new GuardarPagoResponse(mensaje, "Duplicado");
                }
            }
            catch (Exception e)
            {
                return new GuardarPagoResponse($"Error en la aplicacion: {e.Message}", "ErrorAplication");
            }
        }

      

        

        public PagoConsultaResponse Consultar()
        {
            List<Pago> pagos = new List<Pago>();
            try
            {
                return new PagoConsultaResponse(pagos);
            }
            catch (Exception e)
            {
                return new PagoConsultaResponse($"Error en la aplicacion: {e.Message}");
            }
        }


          public BuscarPagoResponse BuscarPago(string numero)
        {
            try
            {
               
                var Pagoresponse = Pagoresponse.Find(s => s.Numero == numero);
                if(Pagoresponse != null)
                {
                    
                    Pagoresponse.Persona = _context.Personas.Find(Pagoresponse.PersonaId);
                    
                    return new BuscarPagoResponse(Pagoresponse);
                }
                else
                {
                    return new BuscarPagoResponse($"No existe");
                }
            }
            catch(Exception e)
            {
                return new BuscarPagoResponse($"Error: {e.Message}");
            }
        }
        public class GuardarPagoResponse
        {
            public GuardarPagoResponse(string mensaje, Pago pago)
            {
                Error = false;
                Mensaje = mensaje;
                Pago = pago;
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
            public Pago Pago { get; set; }
        }
  public class BuscarPagoResponse
        {
            public BuscarPagoResponse(Pago pago)
            {
                Error = false;
                Pago = pago;
            }

            public BuscarPagoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Pago Pago { get; set; }
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
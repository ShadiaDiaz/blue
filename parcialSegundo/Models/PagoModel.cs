using System;
using Entity;


namespace parcialSegundo.Modals
{
    public class PagoInputModels
    {
        public string PersonaId {get;set;}
          public string Cod {get;set;}
         public string TipoPago  {get; set; }
         public DateTime FechaPago { get; set; }
         public decimal ValorPago { get; set; }
         public decimal ValorIva { get; set; }
         public decimal PagoTotal { get; set; }

    }

      public class PagoViewModel : PagoInputModels
    {
        public PagoViewModel()
        {

        }

        public pagoViewModel(Pago pago)
        {
            PersonaId = pago.PersonaId
            Cod = pago.Cod;
            TipoPago = pago.TipoPago;
            FechaPago = pago.FechaPago;
            ValorPago = pago.ValorPago;
            ValorIva = pago.ValorIva;
            PagoTotal = pago.PagoTotal;
           
           
        }
    }
}
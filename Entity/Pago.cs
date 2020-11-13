namespace Entity
{
    public class Pago
    {
         public string PersonaId {get;set;}
         public string Cod {get;set;}
         public string TipoPago  {get; set; }
         public string FechaPago { get; set; }
         public decimal ValorPago { get; set; }
         public decimal ValorIva { get; set; }
         public decimal PagoTotal { get; set; }

        
    }
}
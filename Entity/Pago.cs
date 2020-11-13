namespace Entity
{
    public class Pago
    {
        public string PersonaId {get;set;}
        public string NombrePersona {get;set;}
         public string TipoPago  {get; set; }
         public DateTime FechaPago { get; set; }
         public decimal ValorPago { get; set; }
         public decimal ValorIva { get; set; }
         public decimal PagoTotal { get; set; }

         public decimal PagoTotal(){
             PagoTotal=ValorPago + ValorIva;
         }
    }
}
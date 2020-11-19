using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity
{
    public class Pago
    {
         public string PersonaId {get;set;}
         [Key]
         public string Cod {get;set;}
         public string TipoPago  {get; set; }
         public string FechaPago { get; set; }
         public decimal ValorPago { get; set; }
         public decimal ValorIva { get; set; }
         public decimal PagoTotal { get; set; }

        
    }
}
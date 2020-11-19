using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity
{
    public class Persona
    {
         public string TipoDocumento { get; set; }
         [Key]
         public string Identificacion { get; set; }
         public string Nombres { get; set; }
         public string Direccion { get; set; }
         public int Telefono { get; set; }
         public string Pais { get; set; }
         public string Departamento { get; set; }
         public string Ciudad { get; set; }

    }
}
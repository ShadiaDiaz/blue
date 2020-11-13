using System;
using Entity;


namespace parcialSegundo.Modals
{
    public class PersonaInputModels
    {
         public string TipoDocumento { get; set; }
         public string Identificacion { get; set; }
         public string Nombres { get; set; }
         public string Direccion { get; set; }
         public number Telefono { get; set; }
         public string Pais { get; set; }
         public string Departamento { get; set; }
         public string Ciudad { get; set; }

    }

      public class PersonaViewModel : PersonaInputModels
    {
        public PersonaViewModel()
        {

        }

        public PersonaViewModel(Persona persona)
        {
            TipoDocumento = persona.TipoDocumento
            Identificacion = persona.Identificacion;
            Nombres = persona.Nombres;
            Direccion = persona.Direccion;
            Telefono = persona.Telefono;
            Pais = persona.Pais;
            Departamento = persona.Departamento;
            Ciudad = persona.Ciudad;
           
        }
    }
}
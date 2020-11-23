using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class TipoPersona
    {
        public TipoPersona()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdTipoP { get; set; }
        public string NombreP { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}

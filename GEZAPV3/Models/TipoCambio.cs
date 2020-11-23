using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class TipoCambio
    {
        public TipoCambio()
        {
            Cambios = new HashSet<Cambio>();
        }

        public int IdTipoC { get; set; }
        public string NombreC { get; set; }

        public virtual ICollection<Cambio> Cambios { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public string IdCodF { get; set; }
        public DateTime Fecha { get; set; }
        public int DIdentidad { get; set; }

        public virtual Persona DIdentidadNavigation { get; set; }
        public virtual DetalleFactura DetalleFactura { get; set; }
    }
}

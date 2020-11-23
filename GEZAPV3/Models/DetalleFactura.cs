using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class DetalleFactura
    {
        public int IdDetalle { get; set; }
        public int IdFactura { get; set; }
        public string CodProducto { get; set; }
        public int CantidadVenta { get; set; }

        public virtual Producto CodProductoNavigation { get; set; }
        public virtual Factura IdFacturaNavigation { get; set; }
    }
}

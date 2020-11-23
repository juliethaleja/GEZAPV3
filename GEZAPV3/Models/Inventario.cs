using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class Inventario
    {
        public string IdBodega { get; set; }
        public string CodProducto { get; set; }
        public int IdIngreso { get; set; }
        public int PrecioC { get; set; }
        public int Cantidad { get; set; }

        public virtual Producto CodProductoNavigation { get; set; }
        public virtual Ingreso IdIngresoNavigation { get; set; }
    }
}

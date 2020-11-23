using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class Cambio
    {
        public int IdCambios { get; set; }
        public string CodProducto { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoC { get; set; }

        public virtual Producto CodProductoNavigation { get; set; }
        public virtual TipoCambio IdTipoCNavigation { get; set; }
    }
}

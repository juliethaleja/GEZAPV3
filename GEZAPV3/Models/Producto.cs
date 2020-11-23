using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Cambios = new HashSet<Cambio>();
            DetalleFacturas = new HashSet<DetalleFactura>();
            Inventarios = new HashSet<Inventario>();
        }

        public int IdProducto { get; set; }
        public string CodProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Color { get; set; }
        public int Talla { get; set; }
        public int PrecioVenta { get; set; }
        public int Stock { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<Cambio> Cambios { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            MarcaCategs = new HashSet<MarcaCateg>();
            Productos = new HashSet<Producto>();
        }

        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }

        public virtual ICollection<MarcaCateg> MarcaCategs { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}

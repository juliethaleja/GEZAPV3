using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class MarcaCateg
    {
        public int IdMarcaCateg { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class Marca
    {
        public Marca()
        {
            MarcaCategs = new HashSet<MarcaCateg>();
        }

        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }

        public virtual ICollection<MarcaCateg> MarcaCategs { get; set; }
    }
}

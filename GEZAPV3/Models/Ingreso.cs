using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class Ingreso
    {
        public Ingreso()
        {
            Inventarios = new HashSet<Inventario>();
        }

        public int IdIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Impuesto { get; set; }
        public string Estado { get; set; }
        public string DescripcionEstado { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Facturas = new HashSet<Factura>();
        }

        public int DIdentidad { get; set; }
        public int IdTipoP { get; set; }
        public int? IdUsers { get; set; }
        public string PNombre { get; set; }
        public string SNombre { get; set; }
        public string PApellido { get; set; }
        public string SApellido { get; set; }
        public string TipoD { get; set; }
        public DateTime? FNacimiento { get; set; }
        public string Sexo { get; set; }
        public int Telefono { get; set; }
        public string CElectronico { get; set; }
        public string Direccion { get; set; }

        public virtual TipoPersona IdTipoPNavigation { get; set; }
        public virtual User IdUsersNavigation { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}

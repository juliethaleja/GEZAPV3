using System;
using System.Collections.Generic;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class User
    {
        public User()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdUsers { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}

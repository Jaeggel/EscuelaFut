using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagos.Models
{
    public class Usuario
    {
        public string Nombres{ get; set; }

        public string Apellidos { get; set; }

        public string CI { get; set; }

        public string NombreUsuario { get; set; }

        public string Password { get; set; }

        public string Correo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }
    }
}
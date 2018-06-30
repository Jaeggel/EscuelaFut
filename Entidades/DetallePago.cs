using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class DetallePago
    {
        public Usuarios InfoUsuario { get; set; }

        public double TotalPago { get; set; }

        public DateTime FechaPago { get; set; }

        public int CodigoCupon { get; set; }

        public Boolean BeneficiarioCupon { get; set; }

        public string Observacion{ get; set; }
    }
}

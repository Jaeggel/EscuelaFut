using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaFut.DataTemp
{
    public class Data
    {
        public static List<Usuarios> UsersData = new List<Usuarios> {
            new Usuarios {
                NombreUsuario="admin",
                Nombres="Test",
                Apellidos="Tester",
                Correo="test@mail.com",
                CI="1828281818",
                Direccion="Chillopollo",
                FechaNacimiento=new DateTime(1989,1,20),
                Password="123",
                Telefono="12312312"
            },
            new Usuarios {
                NombreUsuario="test2",
                Nombres="Test2",
                Apellidos="Tester2",
                Correo="test2@mail.com",
                CI="5555555555",
                Direccion="Chillopollox2",
                FechaNacimiento=new DateTime(1989,6,20),
                Password="tst",
                Telefono="12312312"
            }
        };
        public static List<DetallePago> DetallePagosData = new List<DetallePago> {
            new DetallePago{
                InfoUsuario=UsersData[0],
                CodigoCupon=12321,
                FechaPago=new DateTime(2018,06,29),
                Observacion="Pago Adelantado 5 Meses",
                BeneficiarioCupon=true,
                TotalPago=250
            }
        };
    }
}

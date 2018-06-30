using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using EscuelaFut.DataTemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscuelaFut.Controllers
{
    [Route("PagosEscuelaFutbol/[controller]")]
    public class DetallePagosController : Controller
    {
        public static List<DetallePago> LstDetallePagos = new List<DetallePago>();
        [HttpGet("test")]
        public IEnumerable<string> GetTest()
        {
            return new string[] { "abc", "123" };//Test
        }

        [HttpGet("InfoPagos")]
        public IEnumerable<DetallePago> GetDetallePagos()
        {
            LstDetallePagos = Data.DetallePagosData;//Llamar a método de consulta de la base de datos
            return LstDetallePagos;
        }

        [HttpPost("RegistroPagos")]
        public Boolean Post([FromBody] DetallePago infopago)
        {
            infopago.InfoUsuario.Password = string.Empty;
            LstDetallePagos.Add(infopago);//Llamar a método de ingreso a la base de datos
            return true;
        }
    }
}
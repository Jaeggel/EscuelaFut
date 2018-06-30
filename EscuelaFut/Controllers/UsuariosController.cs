using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using EscuelaFut.DataTemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscuelaFut.Controllers
{
    [Route("UsuariosEscuelaFutbol/[controller]")]
    public class UsuariosController : Controller
    {
        public static List<Usuarios> LstUsuarios = new List<Usuarios>();
        [HttpGet("InfoUsuarios")]
        public IEnumerable<Usuarios> GetUsuarios()
        {
            LstUsuarios = Data.UsersData;//Llamar a método de consulta de la base de datos
            return LstUsuarios;
        }

        [HttpPost("RegistroUsuarios")]
        public Boolean Post([FromBody] Usuarios usuario)
        {
            LstUsuarios.Add(usuario);//Llamar a método de ingreso a la base de datos
            return true;
        }
    }
}
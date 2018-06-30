using Pagos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Pagos.ConnService
{
    public class AccService
    {
        public static string Baseurl;
        public AccService()
        {
            Baseurl = ConfigurationManager.AppSettings["URLService"];
        }
        public Boolean AccSendInfoPagos(InfoPagos infopago)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = client.PostAsJsonAsync("EscuelaFut/PagosEscuelaFutbol/DetallePagos/RegistroPagos", infopago).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
        public Boolean AccSendInfoUsuarios(Usuario usuario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = client.PostAsJsonAsync("EscuelaFut/UsuariosEscuelaFutbol/Usuarios/RegistroUsuarios", usuario).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Usuario> AccGetInfoUsuarios()
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("EscuelaFut/UsuariosEscuelaFutbol/Usuarios/InfoUsuarios").Result;
            if (response.IsSuccessStatusCode)
            {
                var users = response.Content.ReadAsStringAsync().Result;
                lstUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(users);
            }
            return lstUsuarios;
        }
    }
}
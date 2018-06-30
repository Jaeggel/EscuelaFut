using Pagos.ConnService;
using Pagos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pagos.Controllers
{
    public class RegistroController : Controller
    {
        public ActionResult Index()
        {
            return View("Registro");
        }

        [HttpPost]
        public ActionResult Registro(Usuario userInfo)
        {
            AccService svc = new AccService();
            if(svc.AccSendInfoUsuarios(userInfo))
            {
                ViewBag.RegisterVerif = string.Format("true");
            }
            return View("Registro", userInfo);
        }
    }
}
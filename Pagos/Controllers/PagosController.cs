using Pagos.ConnService;
using Pagos.Models;
using Pagos.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagos.Controllers
{
    [SessionExpireFilter]
    [OutputCache(NoStore = true, Duration = 0)]
    public class PagosController : Controller
    {
        public static Usuario UserLogin = new Usuario();
        public static string UserName = string.Empty;
        public static string PagoAdelantado = string.Empty;
        public ActionResult Index()
        {
            if (Session["userInfo"] == null)
            {
                return RedirectToAction("Index", "Login", LoginController.userlogin);
            }
            else
            {
                UserLogin = LoginController.userlogin;
                UserName = Session["userInfo"].ToString();
                ViewBag.UserName = UserName.ToUpper();
                ViewBag.User = LoginController.userlogin.NombreUsuario;
                return View("UsuarioPagos");
            }
        }
        public ActionResult FormaPago()
        {
            if (Session["userInfo"] == null)
            {
                return RedirectToAction("Index", "Login", LoginController.userlogin);
            }
            else
            {
                ViewBag.User = LoginController.userlogin.NombreUsuario;
                return View();
            }
        }
        public ActionResult ConfPago()
        {
            if (Session["userInfo"] == null)
            {
                return RedirectToAction("Index", "Login", LoginController.userlogin);
            }
            else
            {
                ViewBag.User = LoginController.userlogin.NombreUsuario;
                Boolean sw=false;
                double total = 50;
                string obsv = "Pago normal de la mensualidad";
                Random random = new Random();
                int numCupon = random.Next(100000, 999999);
                ViewBag.Cupon = numCupon;
                if (PagoAdelantado=="Si")
                {
                    sw = true;
                    total = 250;
                    obsv = "Pago adelantado 5 meses,Beneficiario a cupon Lubricadora";
                }
                InfoPagos pagos = new InfoPagos
                {
                    InfoUsuario = LoginController.userlogin,
                    BeneficiarioCupon = sw,
                    CodigoCupon = numCupon,
                    FechaPago=DateTime.Now,
                    Observacion=obsv,
                    TotalPago=total
                };
                AccService svc = new AccService();
                svc.AccSendInfoPagos(pagos);
                return View();
            }
        }
        [HttpGet]
        public JsonResult GetInfoUser()
        {
            var aux = UserLogin;
            return Json(UserLogin, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void GetRespPagoAd(string respPagoAd)
        {
            PagoAdelantado = respPagoAd;           
        }
        [HttpPost]
        public JsonResult GetTotalPagoAd()
        {
            double total = 0;
            if(PagoAdelantado=="Si")
            {
                total = 250;
            }else
            {
                total = 50;
            }
            return Json(total);
        }
    }
}
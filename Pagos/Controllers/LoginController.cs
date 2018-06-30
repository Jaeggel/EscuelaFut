using Pagos.ConnService;
using Pagos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagos.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
    public class LoginController : Controller
    {
        int SessiontimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
        public static Usuario userlogin = new Usuario();
        public ActionResult Index()
        {
            if (Session["userInfo"] != null)
            {
                return RedirectToAction("Index", "Pagos");
            }
            else
            {
                return View("Login", userlogin);
            }
        }

        [HttpPost]
        public ActionResult Login(Usuario userInfo)
        {
            if (ComprobarUsuario(userInfo))
            {
                Session["userInfo"] = userlogin.Nombres+" "+userlogin.Apellidos;
                Session.Timeout = SessiontimeOut;
                return RedirectToAction("Index", "Pagos");
            }
            else
            {
                ViewBag.MessageError = string.Format("true");
            }
            return View("Login", userlogin);
        }
        public ActionResult CloseSession()
        {
            Session["userInfo"] = null;
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
        public Boolean ComprobarUsuario(Usuario user)
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
            AccService svc = new AccService();
            lstUsuarios=svc.AccGetInfoUsuarios();
            foreach (var item in lstUsuarios)
            {
                if (user.NombreUsuario == item.NombreUsuario && user.Password == item.Password)
                {
                    userlogin = item;
                    return true;
                }
            }
            return false;
        }
    }
}
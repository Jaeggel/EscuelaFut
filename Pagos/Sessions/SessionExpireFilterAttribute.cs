using System.Web;
using System.Web.Mvc;

namespace Pagos.Sessions
{
    public class SessionExpireFilterAttribute : System.Web.Mvc.ActionFilterAttribute
    {        
        /// <summary>
        /// Método para controlar la expiración de la sesión
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["userInfo"] == null)
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
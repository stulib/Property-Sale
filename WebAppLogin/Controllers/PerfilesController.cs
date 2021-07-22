using System.Net.Http;
using System.Web.Mvc;
using WebApp.Security;

namespace WebApp.Controllers
{
    [SecurityFilter]
    public class PerfilesController : Controller
    {
        static HttpClient client = new HttpClient();

        public ActionResult vPerfil_Administrador()
        {
            string RolUsuario = (string)Session["IdRol"];
            if ((Session["UserID"] != null) && (RolUsuario.Equals("01") == true))
            {
                return View("vPerfil_Administrador");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult vPerfil_Admin_Suscripciones()
        {
            string RolUsuario = (string)Session["IdRol"];
            if ((Session["UserID"] != null) && (RolUsuario.Equals("01") == true))
            {
                return View("vPerfil_Admin_Suscripciones");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult vPropiedades()
        {
            string RolUsuario = (string)Session["IdRol"];
            if ((Session["UserID"] != null) && (RolUsuario.Equals("02") == true))
            {
                return View("vPropiedades");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("vLogin", "Home");
        }
    }
}
using System.Net.Http;
using System.Web.Mvc;
using WebApp.Security;

namespace WebApp.Controllers
{
    [SecurityFilter]

    public class RegistrarController : Controller
    {
        static HttpClient client = new HttpClient();

        public ActionResult vReg_Admin()
        {
            string RolUsuario = (string)Session["IdRol"];
            if ((Session["UserID"] != null) & (RolUsuario.Equals("01") == true))
            {
                return View("vReg_Admin");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult vRegistrarBanco()
        {         
                return View("vRegistrarBanco");
        }

        public ActionResult vRegistrarAgencia()
        {
            return View("vRegistrarAgencia");
        }

        public ActionResult vRegistrarPropiedades()
        {
            return View("vRegistrarPropiedades");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("vLogin", "Home");
        }
    }
}
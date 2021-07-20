using Entities_POJO;
using System.Net.Http;
using System.Web.Mvc;
using WebApp.Security;

namespace WebApp.Controllers
{
    [SecurityFilter]
    public class PerfilesControler : Controller
    {
        static HttpClient client = new HttpClient();

        public ActionResult vPerfil_Administrador()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult vPerfil_Admin_Suscripciones()
        {
            if (Session["UserID"] != null)
            {
                return View();
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
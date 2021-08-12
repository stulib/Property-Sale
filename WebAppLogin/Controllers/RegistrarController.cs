using System.Net.Http;
using System.Web.Mvc;
using WebApp.Security;

namespace WebApp.Controllers
{
    [SecurityFilter]

    public class RegistrarController : Controller
    {
        static HttpClient client = new HttpClient();

        public ActionResult vRegistrarBanco()
        {         
                return View("vRegistrarBanco");
        }

        public ActionResult vRegistrarAgencia()
        {
            return View("vRegistrarAgencia");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("vLogin", "Home");
        }
    }
}
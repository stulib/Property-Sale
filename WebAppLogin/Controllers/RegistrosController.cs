using Entities_POJO;
using System.Net.Http;
using System.Web.Mvc;
using WebApp.Security;

namespace WebApp.Controllers
{
    [SecurityFilter]
    public class RegistrosController : Controller
    {
        static HttpClient client = new HttpClient();

        public ActionResult vReg_Admin()
        {
            if ((Session["UserID"] != null) && ((string)Session["IdRol"] != "1"))
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
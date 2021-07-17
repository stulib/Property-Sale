using System.Net.Http;
using System.Web.Mvc;
using WebApp.Security;

namespace WebApp.Controllers
{
    [SecurityFilter]
    public class PerfilesControler : Controller
    {
        static HttpClient client = new HttpClient();

        public ActionResult vPerfilAdministrador()
        {
            return View();
        }
    }
}
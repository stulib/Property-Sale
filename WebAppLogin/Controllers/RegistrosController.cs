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
            return View();
        }
    }
}
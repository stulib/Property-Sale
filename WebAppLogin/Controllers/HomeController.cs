using Entities_POJO;
using System.Web.Mvc;
using WebApp.Security;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    [SecurityFilter]

    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        public ActionResult vPerfil_Administrador() {
                return RedirectToAction("vPerfil_Administrador", "Perfiles");
        }

        public ActionResult vReg_Admin(Usuario user)
        {
            return RedirectToAction("vReg_Admin", "Registros");
        }

        public ActionResult Index(Usuario user)
        {
            if (user.Id != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
       
        public ActionResult vLogin()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();    
            return View("vLogin");
        }

        public ActionResult Error() {
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult vLogin(Usuario objUser)
        {
            if (ModelState.IsValid)

            {
                string jsonString = JsonConvert.SerializeObject(objUser);

                HttpContent c = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("http://localhost:57056/api/signin", c).Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                    var user = JsonConvert.DeserializeObject<Usuario>(apiResponse.Data.ToString());

                    Session["Nombre"] = user.Nombre;
                    Session["UserID"] = user.Id;
                    Session["IdRol"] = user.Id_Rol;
                    return View("Index");
                }
                else
                {
                    return View(objUser);
                }
            }
            return View(objUser);
        }
    }
}
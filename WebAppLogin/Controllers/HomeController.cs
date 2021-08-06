using Entities_POJO;
using System.Web.Mvc;
using WebApp.Security;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using WebApp.Models;
using System;

namespace WebApp.Controllers
{
    [SecurityFilter]

    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        public ActionResult vPerfil_Admin_Suscripciones()
        {
            return RedirectToAction("vPerfil_Admin_Suscripciones", "Perfiles");
        }

        public ActionResult vPerfil_Administrador() {
            return RedirectToAction("vPerfil_Administrador", "Perfiles", new { id = Session["UserID"] });
        }

        public ActionResult vReg_Admin()
        {
            return RedirectToAction("vReg_Admin", "Registros");
        }

        public ActionResult vPropiedades()
        {
            return RedirectToAction("vPropiedades", "Perfiles");
        }

        public ActionResult Index()
        {
                return View();
        }

        public ActionResult vLogin()
        {
            var usuario = new Usuario();
            return View(usuario);
        }

        public ActionResult Logout()
        {
            var usuario = new Usuario();
            Session.Clear();    
            return View("vLogin", usuario);
        }

        public ActionResult RegistrarCuenta() {
            return View();
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

        public ActionResult AccountProfile(Usuario usuario)
        {
            usuario.Id = Session["UserID"].ToString();
            string jsonString = JsonConvert.SerializeObject(usuario);
            HttpContent c = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(String.Format("http://localhost:57056/api/usuario?ID={0}", usuario.Id)).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                var pCuenta = JsonConvert.DeserializeObject<Usuario>(apiResponse.Data.ToString());
                usuario = pCuenta;
            }
            ViewData["Cuenta"] = usuario;
            return View("~/Views/Home/AccountProfile.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _RegistrarBanco(Cuenta objBanco)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View(objBanco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarCuenta(Cuenta objCuenta)
        {
            if (ModelState.IsValid)

            {
                string jsonString = JsonConvert.SerializeObject(objCuenta);

                HttpContent c = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("http://localhost:57056/api/account", c).Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                    var cuenta = JsonConvert.DeserializeObject<Cuenta>(apiResponse.Data.ToString());
                }
                else
                {
                    return View(objCuenta);
                }
            }
            return View("Index");
        }
    }
}
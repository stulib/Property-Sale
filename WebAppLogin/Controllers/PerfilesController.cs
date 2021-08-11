using Entities_POJO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApp.Models;
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

        public ActionResult vSuscripcionAdmin()
        {
            string RolUsuario = (string)Session["IdRol"];
            if ((Session["UserID"] != null) && (RolUsuario.Equals("01") == true))
            {
                return View("vSuscripcionAdmin");
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

        public ActionResult UsuarioProfile(Usuario usuario)
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
            return View("UsuarioProfile");
        }

        public ActionResult AccountProfile(Cuenta cuenta)
        {
            cuenta.ID = Session["UserID"].ToString();
            string jsonString = JsonConvert.SerializeObject(cuenta);
            HttpContent c = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(String.Format("http://localhost:57056/api/account?ID={0}", cuenta.ID)).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                var pCuenta = JsonConvert.DeserializeObject<Cuenta>(apiResponse.Data.ToString());
                cuenta = pCuenta;
            }
            ViewData["Cuenta"] = cuenta;
            return View("AccountProfile");
        }

        public ActionResult Logout()
        {
            var usuario = new Usuario();
            Session.Clear();
            return RedirectToAction("vLogin", "Home", usuario);
        }
    }
}
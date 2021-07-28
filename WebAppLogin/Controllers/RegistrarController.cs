using Entities_POJO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RegistrarController : Controller
    {
        static HttpClient client = new HttpClient();
        // GET: Registrar
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Registrar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _ActualizarCuenta(Cuenta miCuenta)
        {
            ViewData["Cuenta"] = miCuenta;
            return View("~/Views/Home/AccountProfile.cshtml");
        }
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _RegistrarBanco(Cuenta objBanco)
        {
            if (ModelState.IsValid)
            {
                objBanco.TIPO_ID = "Jurídica";
                objBanco.ID_ROL = "05";
                objBanco.ESTADO = "Activo";
                objBanco.VERIFICADO = "N";

                string jsonString = JsonConvert.SerializeObject(objBanco);
                HttpContent c = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("http://localhost:57056/api/account", c).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                    var pCuenta = JsonConvert.DeserializeObject<Cuenta>(apiResponse.Data.ToString());

                    Session["Mensaje"] = pCuenta.Mensaje;

                    ViewData["Cuenta"] = pCuenta;
                    //return View("~/Views/Home/RegistrarCuenta.cshtml");
                    //}
                    //else
                    //{
                    //    return View(objUser);
                }
                else {
                    objBanco.Mensaje = "Ha ocurrido un error";
                    ViewData["Cuenta"] = objBanco;
                }
            }
                return View("~/Views/Home/RegistrarCuenta.cshtml");
            //return View(objBanco);
    }

        // GET: Registrar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registrar/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registrar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registrar/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registrar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registrar/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

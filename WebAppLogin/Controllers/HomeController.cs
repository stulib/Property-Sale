﻿using Entities_POJO;
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

        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("vLogin");
            }
        }

        public ActionResult vCustomers()
        {

            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("vLogin");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult vLogin(UserProfile objUser)
        {
            if (ModelState.IsValid)

            {
                string jsonString = JsonConvert.SerializeObject(objUser);

                HttpContent c = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("http://localhost:57056/api/userProfile", c).Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                    var user = JsonConvert.DeserializeObject<UserProfile>(apiResponse.Data.ToString());

                    Session["UserID"]=user;
                    Session["FullName"] = user.FullName;
                    return View("Index");
                }
                else
                {
                    return View(objUser);
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
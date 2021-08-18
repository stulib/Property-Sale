using Entities_POJO;
using System.Web.Mvc;
using WebApp.Security;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using WebApp.Models;
using System;
using PayPal.Api;
using WebApp.App_Start;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [SecurityFilter]

    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        public ActionResult vVerificarUsuario(string id)
        {
            return RedirectToAction("vVerificarUsuario", "Registrar", new { id = id });
        }

        public ActionResult vVerificacionCompleta()
        {
            return View("vVerificacionCompleta");
        }

        public ActionResult vPerfil_Administrador() {
            return RedirectToAction("vPerfil_Administrador", "Perfiles", new { id = Session["UserID"] });
        }

        public ActionResult vReg_Admin()
        {
            return RedirectToAction("vReg_Admin", "Registrar");
        }

        public ActionResult vSuscripcionAdmin()
        {
            return RedirectToAction("vSuscripcionAdmin", "Perfiles");
        }

        public ActionResult vEquipo()
        {
            return View();
        }

        public ActionResult vPropiedades()
        {
            return RedirectToAction("vPropiedades", "Perfiles");
        }

        public ActionResult vRegistrarAgencia()
        {
            return RedirectToAction("vRegistrarAgencia", "Registrar", new { id = Session["UserID"] });
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
            Session.Clear();    
            return View("Index");
        }

        public ActionResult vRegistrarCuenta() {
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
                    var content = response.Content.ReadAsStringAsync().Result;
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                    ViewBag.Message = apiResponse.ExceptionMessage;
                    return View(objUser);
                }
            }
            return View(objUser);
        }

        public ActionResult AccountProfile()
        {
            return RedirectToAction("AccountProfile", "Perfiles");
        }

        public ActionResult UsuarioProfile()
        {
            return RedirectToAction("UsuarioProfile", "Perfiles", new { id = Session["UserID"] });
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

        public ActionResult PaymentWithPaypal(string Cancel = null)
        { 
            APIContext apiContext = PaypalConfig.GetAPIContext();
            try
            { 
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Home/PaymentWithPayPal?";
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("FailureView");
            }
            //on successful payment, show success page to user.  
            return View("SuccessView");
        }
        private Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = "Suscripción Premium",
                currency = "USD",
                price = "15",
                quantity = "1"
            });
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "1.5",
                subtotal = "16.5"
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = "16.5", // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = "Compra de suscripción premium",
                invoice_number = "6567ADFHGAS", //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "Sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
        }
    }
}
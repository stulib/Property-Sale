using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AccountController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // Retrieve by id
        public IHttpActionResult Post(Cuenta cuenta)
        {
            try
            {
                var mng = new AccountManager();
                cuenta = mng.Create(cuenta);
                apiResp = new ApiResponse
                {
                    Data = cuenta
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Get(String ID)
        {
            try
            {
                var mng = new AccountManager();
                Cuenta cuenta = mng.getAccount(ID);
                apiResp = new ApiResponse
                {
                    Data = cuenta
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Cuenta cuentaC)
        {
            var cuenta = (Usuario)cuentaC;
            try
            {
                var mng = new AccountManager();
                mng.Update(cuenta);
                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
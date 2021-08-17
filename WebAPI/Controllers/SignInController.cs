using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SignInController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Post(Usuario user)
        {
            try
            {
                var mng = new UsuarioManager();
                user = mng.ValidateUser(user);
                apiResp = new ApiResponse();
                apiResp.Data = user;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

    }
}



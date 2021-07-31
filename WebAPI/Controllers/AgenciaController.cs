using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class AgenciaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Post(Agencia agencia)
        {
            try
            {
                var mng = new AgenciaManager();
                mng.Create(agencia);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }
    }
}
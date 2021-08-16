using System;
using CoreAPI;
using Entities_POJO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;
using Exceptions;

namespace WebAPI.Controllers
{
    public class SuscripcionController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new SuscripcionManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new SuscripcionManager();
                var suscripcion = new Suscripcion
                {
                    Id = id
                };

                suscripcion = mng.RetrieveById(suscripcion);
                apiResp = new ApiResponse();
                apiResp.Data = suscripcion;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Suscripcion suscripcion)
        {

            try
            {
                var mng = new SuscripcionManager();
                mng.Create(suscripcion);

                apiResp = new ApiResponse();
                apiResp.Message = "La suscripción fue agregada exitosamente";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Suscripcion suscripcion)
        {
            try
            {
                var mng = new SuscripcionManager();
                mng.Update(suscripcion);

                apiResp = new ApiResponse();
                apiResp.Message = "Suscripción modificada exitosamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Suscripcion suscripcion)
        {
            try
            {
                var mng = new SuscripcionManager();
                mng.Delete(suscripcion);

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
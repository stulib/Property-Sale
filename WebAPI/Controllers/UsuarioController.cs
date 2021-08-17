using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class UsuarioController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new UsuarioManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    Id = id
                };

                usuario = mng.RetrieveById(usuario);
                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Usuario usuario)
        {

            try
            {
                var mng = new UsuarioManager();
                if (usuario.Contrasenna == null)
                {
                    mng.VerifyNewUser(usuario);
                }
                else
                {
                    mng.Create(usuario);
                }

                apiResp = new ApiResponse();
                apiResp.Message = "Usuario registrado correctamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Usuario usuario)
        {
            try
            {
                var mng = new UsuarioManager();
                if (usuario.Contrasenna != null) {
                    mng.Update(usuario);
                } else {
                    mng.UpdateProfile(usuario);
                }
                apiResp = new ApiResponse();
                apiResp.Message = "Perfil actualizado con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Usuario usuario)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.Delete(usuario);

                apiResp = new ApiResponse();
                apiResp.Message = "Usuario eliminado correctamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
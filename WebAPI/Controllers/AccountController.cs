﻿using CoreAPI;
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
                apiResp = new ApiResponse()
                {
                    Data = cuenta
                };
                apiResp.Message = "Usuario Registrado correctamente.";
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

        public IHttpActionResult Put(Cuenta cuenta)
        {
            try
            {
                var mng = new AccountManager();

                mng.UpdateBanco(cuenta);             
                apiResp = new ApiResponse();
                apiResp.Message = "Perfil actualizado con éxito.";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
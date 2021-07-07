using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UserProfileController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();
        // Retrieve by id
        public IHttpActionResult Post(UserProfile user)
        {
            try
            {
                var mng = new UserProfileManager();
              

                user = mng.ValidateUser(user);
                apiResp = new ApiResponse();
                apiResp.Data = user;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}



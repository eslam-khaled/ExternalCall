using Business.Business;
using DTOs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExternalProject.Controllers
{
    public class ExternalController : ApiController
    {
        ExternalCallBusiness externalCallBusiness = new ExternalCallBusiness();


        [HttpPost]
        [Route("API/External")]
        public ResponseDTO ExternalCall(ApiNotificationDTO apiNotificationDTO)
        {
            ResponseDTO responseDTO = externalCallBusiness.Execute(apiNotificationDTO);

            return responseDTO;
        }

    }
}

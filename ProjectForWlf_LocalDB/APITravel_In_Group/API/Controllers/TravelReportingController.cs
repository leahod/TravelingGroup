using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BL;


namespace API.Controllers
{
    [RoutePrefix("api/travelReporting")]
    public class TravelReportingController : ApiController
    {
        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post([FromBody]RegistrationDateRangeDTO traveling)
        {
            try
            {
                TravelReportingBL.AddComplaint(traveling);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

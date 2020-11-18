using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DTO;
using BL;

namespace API.Controllers
{

    [RoutePrefix("api/passengers")]
    public class PassengerController : ApiController
    {
        [HttpGet]
        [Route("Passenger")]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(BL.PassengerBL.GetPassengers());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Passenger/{id}")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                return Ok(BL.PassengerBL.GetPassenger(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post([FromBody]PassngerDTO passenger)
        {
            try
            {
                PassengerBL.Add(passenger);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

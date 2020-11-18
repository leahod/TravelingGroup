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
    [RoutePrefix("api/TravelRange")]
    public class TravelDriverRangeController : ApiController
    {
        [HttpGet]
        [Route("Traveling/{id}")]
        public IHttpActionResult GetByTravelingId(int idTravelingDriver)
        {
            try
            {
                return Ok(BL.TravelingDriverBL.GetTraveling(idTravelingDriver));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Travelings/{id}")]
        public IHttpActionResult GetByPassengerId(int id)
        {
            try
            {
                return Ok(BL.TravelingDriverBL.GetTravelings(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post([FromBody]TravelingDriverDTO traveling)
        {        
            try
            {
                TravelingDriverBL.Add(traveling);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("driversSuitable/{id}")]
        public IHttpActionResult GetSuitableTravelingToPassenger(int id)
        {
            try
            {
                return Ok(BL.TravelingDriverBL.GetTravelingsToPassenger(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("sendMail")]
        public IHttpActionResult Post([FromBody]DTO.JoinTraveling details)
        {
            try
            {
                return Ok(BL.Mail.MailDriverToConfirm(details.idTravelingD, details.idTravelingP, "jmb", "vcb"));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}


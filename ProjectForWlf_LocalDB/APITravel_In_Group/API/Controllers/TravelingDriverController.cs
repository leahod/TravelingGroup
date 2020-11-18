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
    [RoutePrefix("api/travelingDriver")]
    public class TravelingDriverController : ApiController
    {
        [HttpGet]
        [Route("travelingD/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(BL.TravelingDriverBL.GetTraveling(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddTraveling([FromBody]TravelingDriverDTO traveling)
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

        [HttpGet]
        [Route("TravelingsAttached/{id}")]
        public IHttpActionResult GetTravelingsAttached(int id)
        {
            try
            {
                return Ok(TravelingDriverBL.GetTravelAttached(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("TravelingsNotAttached/{id}")]
        public IHttpActionResult GetTravelingsNotAttached(int id)
        {
            try
            {
                return Ok(TravelingDriverBL.GetTravelUnAttached(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult DeleteTravelingDriver([FromBody]TravelingDriverDTO traveling)
        {
            try
            {
                TravelingDriverBL.DeleteTraveling(traveling);
                return Ok();
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


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
    [RoutePrefix("api/travelingPassenger")]

    public class TravelingPassengerController : ApiController
    {
        [HttpGet]
        [Route("Travelings/{id}")]
        public IHttpActionResult GetByPassengerId(int id)
        {
            try
            {
                return Ok(BL.TravelingPassengerBL.GetTravelings(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Traveling/{id}")]
        public IHttpActionResult GetByTravelingId(int id)
        {
            try
            {
                return Ok(BL.TravelingPassengerBL.GetTraveling(id));
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
                return Ok(BL.TravelingPassengerBL.GetTravelAttached(id));
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
                return Ok(BL.TravelingPassengerBL.GetTravelNotAttached(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddTraveling([FromBody]TravelingPassengerDTO traveling)
        {
            try
            {
                traveling.IsEmbedded = false;
                return Ok(TravelingPassengerBL.Add(traveling));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("sendMail")]
        public IHttpActionResult SendMail([FromBody]DTO.JoinTraveling details)
        {
            try
            {
                return Ok(BL.Mail.MailPassengerToConfirm(details.idTravelingD, details.idTravelingP, "jmb", "vcb"));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Put([FromBody]TravelingPassengerDTO traveling)
        {
            try
            {
                TravelingPassengerBL.UpdateTraveling(traveling);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult DeleteTravellingDriver([FromBody]TravelingPassengerDTO traveling)
        {
            try
            {
                TravelingPassengerBL.DeleteTraveling(traveling);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("addReport")]
        public IHttpActionResult AddReport([FromBody]TravelingPassengerDTO traveling)
        {
            try
            {
                traveling.IsEmbedded = false;
                return Ok(TravelingPassengerBL.Add(traveling));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}

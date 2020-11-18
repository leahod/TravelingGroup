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
    [RoutePrefix("api/Registeration")]
    public class RegisterationController : ApiController
    {
        [HttpGet]
        [Route("Registerations/{id}")]
        public IHttpActionResult GetRegisterationByPassengerId(int id)
        {
            try
            {
                return Ok(BL.RegisterationBL.GetRegisterationByPassengerId(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("RegisterationsD/{id}")]
        public IHttpActionResult GetRegisterationByDriverId(int id)
        {
            try
            {
                return Ok(BL.RegisterationBL.GetRegisterationByDriverId(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post([FromBody]RegisterationDTO registeration)
        {
            try
            {
                RegisterationBL.Add(registeration);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("deleteRangeRegP")]
        public IHttpActionResult DeleteRegisterationPassenger([FromBody]TravelingPassengerDTO traveling)
        {
            try
            {
                RegisterationDTO registeration = RegisterationBL.GetRegisterationByPassengerId(traveling.TravelingIdPassenger);
                return Ok(RegisterationBL.DeleteRangeRegPassenger(registeration.Id, traveling.FromDate.Date, traveling.ToDate));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("deleteRangeRegD")]
        public IHttpActionResult DeleteRegisterationDriver([FromBody]TravelingDriverDTO traveling)
        {
            try
            {
                BL.RegisterationBL.DeleteRegisterationDriver(traveling);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

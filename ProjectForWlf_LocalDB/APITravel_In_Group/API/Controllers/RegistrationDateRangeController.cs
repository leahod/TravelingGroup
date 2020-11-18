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
    [RoutePrefix("api/RegisterationDateRange")]
    public class RegistrationDateRangeController : ApiController
    {
        [HttpGet]
        [Route("RegisterationDates/{id}")]
        public IHttpActionResult GetRegisterationDatesById(int id)
        {
            try
            {
                return Ok(BL.RegistrationDateRangeBL.GetRegistrationDates(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("RegisterationsDateRange/{id}")]
        public IHttpActionResult GetRegisterationByDriverId(int id)
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
    }
}

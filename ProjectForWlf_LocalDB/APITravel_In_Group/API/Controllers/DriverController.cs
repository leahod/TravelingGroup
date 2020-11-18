using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using BL;
using System.Web.Http;


namespace API.Controllers
{
    [RoutePrefix("api/drivers")]
    public class DriverController : ApiController
    {
        [HttpGet]
        [Route("Drivers")]
        public IHttpActionResult GetDrivers()
        {
            try
            {
                return Ok(BL.DriverBL.GetDrivers());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Driver/{id}")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                return Ok(BL.DriverBL.GetDriver(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post([FromBody]DriverDTO driver)
        {
            try
            {
                DriverBL.Add(driver);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Put(string id, [FromBody]DriverDTO driver)
        {
            try
            {
                DriverBL.UpdateDriver(id, driver);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
       
    }
}
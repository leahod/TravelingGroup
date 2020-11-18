
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/statistics")]
    public class StatisticsController : ApiController
    {
        [HttpGet]
        [Route("Gender")]
        public IHttpActionResult GetGender()
        {
            try
            {
                return Ok(BL.StatisticsBL.GetGender());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Days")]
        public IHttpActionResult GetDays()
        {
            try
            {
                return Ok(BL.StatisticsBL.GetDays());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("AvgPassengers")]
        public IHttpActionResult GetAvgPassengers()
        {
            try
            {
                return Ok(BL.StatisticsBL.GetAvgPassengers());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("TravelCost")]
        public IHttpActionResult GetTravelCost()
        {
            try
            {
                return Ok(BL.StatisticsBL.GetTravelCost());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

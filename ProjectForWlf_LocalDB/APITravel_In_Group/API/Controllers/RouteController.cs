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
    [RoutePrefix("api/route")]
    public class RouteController : ApiController
    {
        [HttpGet]
        [Route("getRoute/{id}")]
        public IHttpActionResult GetRouteByTravelD(int id)
        {
            try
            {
                return Ok(BL.RouteBL.GetListWayPointsByTravelD(id));
               
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

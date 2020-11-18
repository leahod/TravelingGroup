using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/Payment")]
    public class PaymentController : ApiController
    {
        [HttpGet]
        [Route("PaymentsByIdP/{id}")]
        public IHttpActionResult GetPaymentsByIdP(int id)
        {
            try
            {
                return Ok(BL.PaymentBL.GetPaymentsP(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpGet]
        [Route("PaymentsByIdD/{id}")]
        public IHttpActionResult GetPaymentsByIdD(int id)
        {
            try
            {
                return Ok(BL.PaymentBL.GetPaymentsD(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

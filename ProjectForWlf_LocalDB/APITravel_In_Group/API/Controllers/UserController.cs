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
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("Users")]
        public IHttpActionResult GetUsers()
        {
            try
            {
            
                return Ok(BL.UserBL.GetUsers());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("User/{id}")]
        public IHttpActionResult Get(string id)
        {
            try
            {
           
                return Ok(BL.UserBL.GetUser(id));
             
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post([FromBody]DTO.UserDTO userDTO)
        {
            try
            {
                return Ok(BL.UserBL.Add(userDTO));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public void Put(string id, [FromBody]DTO.UserDTO userDTO)
        {
            BL.UserBL.UpdateUser(id, userDTO);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(string id)
        {
            BL.UserBL.DeleteUser(id);
        }
    }
}

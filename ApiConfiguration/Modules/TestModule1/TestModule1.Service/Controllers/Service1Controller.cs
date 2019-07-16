using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TestModule1.Interfaces;

namespace TestModule1.Controllers
{
    [Route("api/service1")]
    [ApiController]
    public class Service1Controller : ControllerBase
    {
        private IService1 service;

        public Service1Controller(IService1 service)
        {
            this.service = service;
        }

        [HttpGet("string")]
        public ActionResult<string> GetString()
        {

            return Ok("dupa");
        }
    }
}

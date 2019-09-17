using App.Services.Test1;
using App.Services.Test1.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    [Route("api/test1")]
    public class Test1Controller : ControllerBase
    {
        private ITest1Serivice service;

        public Test1Controller(ITest1Serivice service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public ActionResult GetValue(int id)
        {
            return Ok(service.GetValue(id));
        }

        [HttpPost]
        public ActionResult AddTest1([FromBody]Test1DTO test1)
        {
            service.AddTest1(test1);
            return Ok();
        }

        [HttpGet("cities")]
        public ActionResult GetCities()
        {
            return Ok(service.GetCities());
        }
    }
}

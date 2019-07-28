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
        private ITest1Serivice businessLogic;

        public Test1Controller(ITest1Serivice businessLogic)
        {
            this.businessLogic = businessLogic;
        }

        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            return Ok(businessLogic.GetValue(id));
        }

        [HttpPost]
        public IActionResult AddTest1([FromBody]Test1DTO test1)
        {
            businessLogic.AddTest1(test1);
            return Ok();
        }
    }
}

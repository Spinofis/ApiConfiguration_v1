using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        [HttpGet("{name}")]
        public IActionResult DownloadFile(string name)
        {
            //return File()
        }
    }
}

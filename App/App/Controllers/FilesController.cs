using App.Services.Files;
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
        private IFileService service;

        public FilesController(IFileService service)
        {
            this.service = service;
        }

        [HttpGet("{name}")]
        public IActionResult DownloadFile(string name)
        {
            var stream = service.DownloadFile(name);
            return File(stream.Stream.ToArray(), stream.ContentType);
        }
    }
}

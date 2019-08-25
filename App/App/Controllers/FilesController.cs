using App.Services.Files;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("directory")]
        public IActionResult CreateAzureContainer([FromBody]List<string> folders)
        {
            service.CreateAzureDirectory(folders);
            return Ok();
        }

        [HttpPost("upload")]
        public IActionResult UploadFile(IFormFile file,string folder)
        {
            service.UploadFile(file,folder);
            return Ok();
        }
    }
}

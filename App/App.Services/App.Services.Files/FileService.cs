using App.Base.Extensions;
using System;
using System.IO;

namespace App.Services.Files
{
    public class FileService : IFileService
    {
        public ExtendedMemoryStream DownloadFile(string name)
        {
            var bytes = File.ReadAllBytes(Path.Combine(@"C:\Users\Bartek\Desktop)", name));
            var stream = new MemoryStream(bytes);
            var contentType = "application/octet-stream";
            return new ExtendedMemoryStream(name, stream, contentType);
        }
    }

}
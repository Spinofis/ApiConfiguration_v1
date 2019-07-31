using System;
using System.IO;

namespace App.Services.Files
{
    public class FileService : IFileService
    {
        public byte[] DownloadFile(string name)
        {
            return File.ReadAllBytes(Path.Combine(@"C:\Users\Bartek\Desktop)", name));
        }
    }
}

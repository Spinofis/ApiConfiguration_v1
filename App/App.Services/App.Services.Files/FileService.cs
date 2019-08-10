using App.AzureStorageManager;
using App.Base.Extensions;
using System;
using System.Collections.Generic;
using System.IO;

namespace App.Services.Files
{
    public class FileService : IFileService
    {
        IAzureFileManager azureStorageManager;

        public FileService(IAzureFileManager azureStorageManager)
        {
            this.azureStorageManager = azureStorageManager;
        }

        public ExtendedMemoryStream DownloadFile(string name)
        {
            var bytes = File.ReadAllBytes(Path.Combine(@"C:\Users\Bartek\Desktop", name));
            var stream = new MemoryStream(bytes);
            var contentType = "application/octet-stream";
            return new ExtendedMemoryStream(name, stream, contentType);
        }


        public void CreateAzureDirectory(List<string> folders)
        {
            azureStorageManager.CreateDirectoryAsync(string.Join("/", folders));
        }
    }

}
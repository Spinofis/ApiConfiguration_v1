using App.AzureStorageManager;
using App.Base.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace App.Services.Files
{
    public class FileService : IFileService
    {
        IAzureFileManager azureFileManager;

        public FileService(IAzureFileManager azureStorageManager)
        {
            this.azureFileManager = azureStorageManager;
        }

        public ExtendedMemoryStream DownloadFile(string path)
        {
            var bytes = azureFileManager.DownloadFile(path);
            var stream = new MemoryStream(bytes);
            var contentType = "application/octet-stream";
            return new ExtendedMemoryStream(path, stream, contentType);
        }

        public void CreateAzureDirectory(List<string> folders)
        {
            azureFileManager.CreateDirectory(string.Join("/", folders));
        }

        public void UploadFile(IFormFile file, string folder)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                azureFileManager.UploadFile(Path.Combine(folder, file.FileName), ms.ToArray());
            }
        }
    }

}
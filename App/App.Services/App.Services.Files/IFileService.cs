using App.Base.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.Files
{
    public interface IFileService
    {
        ExtendedMemoryStream DownloadFile(string name);

        void CreateAzureDirectory(List<string> folders);
    }
}

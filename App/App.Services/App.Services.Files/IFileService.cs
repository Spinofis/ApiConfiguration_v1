using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.Files
{
    public interface IFileService
    {
        byte[] DownloadFile(string name);
    }
}

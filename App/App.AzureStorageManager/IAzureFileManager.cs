using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.AzureStorageManager
{
    public interface IAzureFileManager
    {
        void CreateDirectory(string name);

        void UploadFile(string path, byte[] bytes);

        byte[] DownloadFile(string path);
    }
}

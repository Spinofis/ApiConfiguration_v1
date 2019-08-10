using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.AzureStorageManager
{
    public interface IAzureFileManager
    {
        void CreateDirectoryAsync(string name);
    }
}

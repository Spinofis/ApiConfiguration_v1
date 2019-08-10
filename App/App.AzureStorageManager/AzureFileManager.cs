using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.File;
using System;
using System.Threading.Tasks;

namespace App.AzureStorageManager
{
    public class AzureFileManager : IAzureFileManager
    {
        private CloudStorageAccount storageAccount;

        private CloudFileClient cloudFileClient;

        private string rootDir;

        public AzureFileManager(string key, string rootDir)
        {
            CloudStorageAccount.TryParse(key, out storageAccount);
            this.cloudFileClient = storageAccount.CreateCloudFileClient();
            this.rootDir = rootDir;
        }

        public async void CreateDirectoryAsync(string name)
        {
            CloudFileDirectory directory = cloudFileClient.GetShareReference(rootDir).GetRootDirectoryReference();

            string[] folders = name.Split("/");

            foreach (string folder in folders)
            {
                directory = directory.GetDirectoryReference(folder);
                if (!directory.Exists())
                    await directory.CreateAsync();
            }
        }
    }
}

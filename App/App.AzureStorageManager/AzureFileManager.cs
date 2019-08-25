using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.File;
using System;
using System.IO;
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

        private string[] GetArrrayOfFolders(string path)
        {
            string[] folders = path.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);

            return folders;
        }

        private byte[] StreamToByteArray(Stream stream)
        {
            byte[] buffer = new byte[4 * 1024];

            using (MemoryStream ms = new MemoryStream())
            {
                while (stream.Read(buffer, 0, buffer.Length) > 0)
                {
                    ms.Write(buffer);
                }

                return ms.ToArray();
            }
        }

        private CloudFile GetCloudFileReference(string path, bool createIfNotExist = false)
        {
            CloudFileDirectory directory = cloudFileClient.GetShareReference(rootDir).GetRootDirectoryReference();
            CloudFile file = null;

            string[] folders = GetArrrayOfFolders(path);

            for (int i = 0; i < folders.Length; i++)
            {
                if (i == folders.Length - 1)
                {
                    file = directory.GetFileReference(folders[i]);
                    if (!file.Exists() && createIfNotExist)
                        file.Create(0L);
                }
                else
                {
                    directory = directory.GetDirectoryReference(folders[i]);
                    if (!directory.Exists() && createIfNotExist)
                        directory.Create();
                }
            }

            return file;
        }

        public void CreateDirectory(string name)
        {
            CloudFileDirectory directory = cloudFileClient.GetShareReference(rootDir).GetRootDirectoryReference();

            string[] folders = GetArrrayOfFolders(name);

            foreach (string folder in folders)
            {
                directory = directory.GetDirectoryReference(folder);
                if (!directory.Exists())
                    directory.Create();
            }
        }

        public void UploadFile(string path, byte[] bytes)
        {
            CloudFile file = GetCloudFileReference(path);

            file.UploadFromByteArray(bytes, 0, bytes.Length);
        }

        public byte[] DownloadFile(string path)
        {
            CloudFile file = GetCloudFileReference(path);
            return StreamToByteArray(file.OpenRead());
        }
    }
}

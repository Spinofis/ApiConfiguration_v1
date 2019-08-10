using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App.Base.Extensions
{
    public class ExtendedMemoryStream : IDisposable
    {
        public string Name { get; set; }

        public MemoryStream Stream { get; set; }

        public string ContentType { get; set; }

        public ExtendedMemoryStream(string name, MemoryStream stream, string contentType)
        {
            Name = name;
            Stream = stream;
            ContentType = contentType;
        }

        public void Dispose()
        {
            if (Stream != null)
                Stream.Dispose();
        }
    }
}

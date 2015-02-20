using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XavierEnterpriseLibrary.Infrastructure.Getters
{
    public class FileByteArrayGetter : XavierEnterpriseLibrary.Core.Interfaces.IFileByteArrayGetter
    {
        public byte[] GetByteArrayFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            Byte[] result = null;

            using (var memoryStream = new MemoryStream())
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    fileStream.CopyTo(memoryStream);

                    result = memoryStream.ToArray();
                }
            }

            return result;
        }
    }
}

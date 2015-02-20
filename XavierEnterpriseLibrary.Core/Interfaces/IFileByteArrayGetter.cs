using System;
namespace XavierEnterpriseLibrary.Core.Interfaces
{
    public interface IFileByteArrayGetter
    {
        byte[] GetByteArrayFromFile(string filePath);
    }
}

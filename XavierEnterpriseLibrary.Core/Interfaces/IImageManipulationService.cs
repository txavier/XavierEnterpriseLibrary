using System;
namespace XavierEnterpriseLibrary.Core.Interfaces
{
    public interface IImageManipulationService
    {
        string GetBarcodeBase64String(ZXing.BarcodeFormat barcodeFormat, string code, System.Drawing.RotateFlipType rotateFlipType = System.Drawing.RotateFlipType.RotateNoneFlipNone);
        System.Drawing.Bitmap GetBarcodeBitmap(ZXing.BarcodeFormat barcodeFormat, string code, System.Drawing.RotateFlipType rotateFlipType);
        byte[] GetBarcodeByteArray(ZXing.BarcodeFormat barcodeFormat, string code, System.Drawing.RotateFlipType rotateFlipType);
        string GetBarcodeDataUri(ZXing.BarcodeFormat barcodeFormat, string code, System.Drawing.RotateFlipType rotateFlipType = System.Drawing.RotateFlipType.RotateNoneFlipNone);
        byte[] GetBitmapByteArray(System.Drawing.Bitmap result);
        string GetDataURI(string mimeType, string base64);
        string GetImageBase64String(string filePath);
        string GetJpgImageDataUri(string filePath);
    }
}

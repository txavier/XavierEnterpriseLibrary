using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace XavierEnterpriseLibaray.ImageManipulation
{
    public class ImageManipulationService
    {
        /// <summary>
        /// This gets the datauri for a specified mimetype and base 64 string.
        /// </summary>
        /// <param name="mimeType">The mimetype (i.e. [image/jpg]).</param>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static string GetDataURI(string mimeType, string base64)
        {
            var result = new StringBuilder("data:").Append(mimeType).Append(";base64,").Append(base64);

            return result.ToString();
        }

        public static string GetBarcodeDataUri(BarcodeFormat barcodeFormat, string code, RotateFlipType rotateFlipType = RotateFlipType.RotateNoneFlipNone)
        {
            var result = GetBarcodeBase64String(BarcodeFormat.CODE_128, code, RotateFlipType.Rotate90FlipNone);

            var dataUri = GetDataURI("image/jpg", result);

            return dataUri;
        }

        public static string GetJpgImageDataUri(string filePath)
        {
            var result = GetImageBase64String(filePath);

            var dataUri = GetDataURI("image/jpg", result);

            return dataUri;
        }

        /// <summary>
        /// This method returns a bar-code in a base64 encoded string.
        /// </summary>
        /// <param name="barcodeFormat"></param>
        /// <param name="code"></param>
        /// <param name="rotateFlipType"></param>
        /// <returns></returns>
        public static string GetBarcodeBase64String(BarcodeFormat barcodeFormat, string code, RotateFlipType rotateFlipType = RotateFlipType.RotateNoneFlipNone)
        {
            var imageBytes = GetBarcodeByteArray(barcodeFormat, code, rotateFlipType);

            var base64String = Convert.ToBase64String(imageBytes);

            return base64String;
        }

        /// <summary>
        /// This method gets a base 64 encoded string from a jpg image found in the file path.
        /// </summary>
        /// <remarks>
        /// For further information on the coding path chosen please see this page:
        /// http://stackoverflow.com/questions/7240216/convert-an-image-to-base64-and-vice-versa
        /// </remarks>
        /// <param name="filePath">Path to the jpg image.</param>
        /// <returns>Base 64 encoded string.</returns>
        public static string GetImageBase64String(string filePath)
        {
            var imageBytes = GetByteArrayFromFile(filePath);

            var base64String = Convert.ToBase64String(imageBytes);

            return base64String;
        }

        public static byte[] GetBarcodeByteArray(BarcodeFormat barcodeFormat, string code, RotateFlipType rotateFlipType)
        {
            var result = GetBarcodeBitmap(barcodeFormat, code, rotateFlipType);

            var imageBytes = GetBitmapByteArray(result);

            return imageBytes;
        }

        public static byte[] GetBitmapByteArray(Bitmap result)
        {
            var stream = new System.IO.MemoryStream();

            result.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

            var imageBytes = stream.ToArray();

            return imageBytes;
        }

        public static Bitmap GetBarcodeBitmap(BarcodeFormat barcodeFormat, string code, RotateFlipType rotateFlipType)
        {
            IBarcodeWriter writer = new BarcodeWriter() { Format = barcodeFormat };

            var result = writer.Write(code);

            // Rotate the image so that it is on its side.
            result.RotateFlip(rotateFlipType);

            return result;
        }

        public static byte[] GetByteArrayFromFile(string filePath)
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

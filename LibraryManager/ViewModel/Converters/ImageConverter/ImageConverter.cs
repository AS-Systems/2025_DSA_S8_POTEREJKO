using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace LibraryManager.ViewModel.Converters.ImageConverter
{
    public class ImageConverter : IImageConverter
    {
        public BitmapImage BlobToImage(byte[] blob)
        {
            if (blob == null || blob.Length == 0)
                throw new ArgumentNullException(nameof(blob));

            using (var memoryStream = new MemoryStream(blob))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad; 
                bitmap.StreamSource = memoryStream;
                bitmap.EndInit();
                bitmap.Freeze(); 
                return bitmap;
            }
        }

        public byte[] ImageToBlob(BitmapImage bitmapImage)
        {
            if (bitmapImage == null)
                throw new ArgumentNullException(nameof(bitmapImage));

            using (var memoryStream = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder(); 
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}

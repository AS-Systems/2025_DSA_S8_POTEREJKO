using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.ViewModel.Converters.ImageConverter
{
    public class ImageConverter : IImageConverter
    {
        public Image BlobToImage(byte[] blob)
        {
            if (blob == null || blob.Length == 0) throw new ArgumentNullException(nameof(blob));

            using (var memoryStream = new MemoryStream(blob))
            {
                return Image.FromStream(memoryStream);
            }
        }

        public byte[] ImageToBlob(Image image)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));

            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }
    }
}

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;

public interface IImageConverter
{
    byte[] ImageToBlob(Image image);
    Image BlobToImage(byte[] blob);
}

public class ImageConverter : IImageConverter
{
    public byte[] ImageToBlob(Image image)
    {
        if (image == null) throw new ArgumentNullException(nameof(image));

        using (var memoryStream = new MemoryStream())
        {
            image.Save(memoryStream, ImageFormat.Png); // Save as PNG or other format  
            return memoryStream.ToArray();
        }
    }

    public Image BlobToImage(byte[] blob)
    {
        if (blob == null || blob.Length == 0) throw new ArgumentNullException(nameof(blob));

        using (var memoryStream = new MemoryStream(blob))
        {
            return Image.FromStream(memoryStream);
        }
    }
}

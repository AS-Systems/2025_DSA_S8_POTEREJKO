using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

public interface IImageConverter
{
    byte[] ImageToBlob(Image image);
    Image BlobToImage(byte[] blob);
}


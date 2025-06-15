using System.Windows.Media.Imaging;

public interface IImageConverter
{
    byte[] ImageToBlob(BitmapImage bitmapImage);
    BitmapImage BlobToImage(byte[] blob);
}


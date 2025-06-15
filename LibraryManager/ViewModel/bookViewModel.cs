using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using LibraryManager.Model;
using LibraryManager.Model.Entities;
using LibraryManager.ViewModel.Converters.ImageConverter;

public class BookViewModel
{
    private readonly IImageConverter _imageConverter;
    private readonly HomelibraryContext _dbContext;

    //
    public Book CurrentBook { get; set; } = new Book();

    public BookViewModel(IImageConverter imageConverter, HomelibraryContext dbContext)
    {
        _imageConverter = imageConverter;
        _dbContext = dbContext;
    }

    // Called when user drops/selects an image
    public void SetCoverImageFromFile(string filePath)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };
        var ext = Path.GetExtension(filePath).ToLower();
        if (!allowedExtensions.Contains(ext))
            throw new InvalidDataException("Unsupported file type.");

        var fileInfo = new FileInfo(filePath);
        if (fileInfo.Length > 2 * 1024 * 1024) // 2MB limit
            throw new InvalidDataException("File too large.");

        using var image = Image.FromFile(filePath);
       // CurrentBook.Cover = _imageConverter.ImageToBlob(image);
    }

    // Save to database
    public async Task SaveBookAsync()
    {
        if (CurrentBook.Id == 0)
            _dbContext.Books.Add(CurrentBook);
        else
            _dbContext.Books.Update(CurrentBook);

        await _dbContext.SaveChangesAsync();
    }

    // For displaying in WPF Image control
    public BitmapImage? CoverImageDisplay
    {
        get
        {
            if (CurrentBook.Cover == null) return null;
            using var ms = new MemoryStream(CurrentBook.Cover);
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = ms;
            bitmap.EndInit();
            bitmap.Freeze();
            return bitmap;
        }
    }
}

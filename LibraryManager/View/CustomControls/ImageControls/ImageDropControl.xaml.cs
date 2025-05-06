using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManager.View.CustomControls.ImageControls
{
    /// <summary>
    /// Logika interakcji dla klasy ImageDropControl.xaml
    /// </summary>
    public partial class ImageDropControl : UserControl
    {
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(int), typeof(ImageDropControl), new PropertyMetadata(25));


        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }



        public ImageDropControl()
        {
            InitializeComponent();
            ActionImage.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "image-icon.png")));
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && IsImageFile(files[0]))
                {
                    try
                    {
                        var bitmap = new BitmapImage(new Uri(files[0]));
                        DroppedImage.Source = bitmap;
                        DroppedImage.Visibility = Visibility.Visible;
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
        }

        private bool IsImageFile(string path)
        {
            string ext = System.IO.Path.GetExtension(path)?.ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png";
        }

    }

    public class RectConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != DependencyProperty.UnsetValue && values[1] != DependencyProperty.UnsetValue)
            {
                double width = (double)values[0];
                double height = (double)values[1];
                return new Rect(0, 0, width, height);
            }
            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

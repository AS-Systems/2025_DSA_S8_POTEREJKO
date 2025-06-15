using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibraryManager.View.CustomControls.ImageControls
{
    /// <summary>
    /// Logika interakcji dla klasy ImageDisplayControl.xaml
    /// </summary>
    public partial class ImageDisplayControl : UserControl
    {
        public static readonly DependencyProperty DisplayImageSourceProperty = DependencyProperty.Register("DisplayImageSource", typeof(ImageSource), typeof(ImageDisplayControl), new PropertyMetadata(null));
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(int), typeof(ImageDisplayControl), new PropertyMetadata(25));

        public ImageSource? DisplayImageSource
        {
            get { return (ImageSource)GetValue(DisplayImageSourceProperty); }
            set { SetValue(DisplayImageSourceProperty, value); }
        }

        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public ImageDisplayControl()
        {
            InitializeComponent();
        }
    }
}

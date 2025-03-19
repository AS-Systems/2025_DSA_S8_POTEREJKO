using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace LibraryManager.View.CustomControls.Buttons
{
    /// <summary>
    /// Logika interakcji dla klasy PageSelectionButton.xaml
    /// </summary>
    public partial class PageSelectionButton : UserControl
    {
        public PageSelectionButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(int), typeof(PageSelectionButton), new PropertyMetadata(300));
        public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof(int), typeof(PageSelectionButton), new PropertyMetadata(100));
        public static readonly DependencyProperty ButtonFontSizeProperty = DependencyProperty.Register("ButtonFontSize", typeof(int), typeof(PageSelectionButton), new PropertyMetadata(50));
        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Brush), typeof(PageSelectionButton), new PropertyMetadata(Brushes.LightGray));
        public static readonly DependencyProperty FontColorProperty = DependencyProperty.Register("FontColor", typeof(Brush), typeof(PageSelectionButton), new PropertyMetadata(Brushes.Black));
        public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register("ButtonText", typeof(string), typeof(PageSelectionButton), new PropertyMetadata("Text"));
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register("ImagePath", typeof(string), typeof(PageSelectionButton), new PropertyMetadata(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "image-icon.png")));
        public static readonly DependencyProperty ButtonHoverColorProperty = DependencyProperty.Register("ButtonHoverColor", typeof(Brush), typeof(PageSelectionButton), new PropertyMetadata(Brushes.Gray));
        public static readonly DependencyProperty ButtonClickColorProperty =  DependencyProperty.Register("ButtonClickColor", typeof(Brush), typeof(PageSelectionButton), new PropertyMetadata(Brushes.DarkGray));
        public static readonly DependencyProperty ButtonClickedImagePathProperty = DependencyProperty.Register("ButtonClickedImagePath", typeof(string), typeof(PageSelectionButton), new PropertyMetadata(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "image-icon.png")));

        public int Width
        {
            get { return (int)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public int Height
        {
            get { return (int)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        public int ButtonFontSize
        {
            get { return (int)GetValue(ButtonFontSizeProperty); }
            set { SetValue(ButtonFontSizeProperty, value); }
        }

        public int ImageSide => (int)Math.Round(((double)Height / 100) * 60, MidpointRounding.ToEven);

        public Brush BackgroundColor
        {
            get { return (Brush)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public Brush FontColor
        {
            get { return (Brush)GetValue(FontColorProperty); }
            set { SetValue(FontColorProperty, value); }
        }

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        public Brush ButtonHoverColor
        {
            get { return (Brush)GetValue(ButtonHoverColorProperty); }
            set { SetValue(ButtonHoverColorProperty, value); }
        }

        public Brush ButtonClickColor
        {
            get { return (Brush)GetValue(ButtonClickColorProperty); }
            set { SetValue(ButtonClickColorProperty, value); }
        }

        public string ButtonClickedImagePath
        {
            get { return (string)GetValue(ButtonClickedImagePathProperty); }
            set { SetValue(ButtonClickedImagePathProperty, value); }
        }

    }
}

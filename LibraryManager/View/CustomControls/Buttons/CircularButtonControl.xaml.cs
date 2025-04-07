using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LibraryManager.View.CustomControls
{
    /// <summary>
    /// Logika interakcji dla klasy CircularButtonControl.xaml
    /// </summary>
    public partial class CircularButtonControl : UserControl
    {

        public CircularButtonControl()
        {
            InitializeComponent(); 
            
        }

        public static readonly DependencyProperty DiameterProperty =
            DependencyProperty.Register("Diameter", typeof(int), typeof(CircularButtonControl), new PropertyMetadata(50));

        public static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.Register("BackgroundColor", typeof(Brush), typeof(CircularButtonControl), new PropertyMetadata(Brushes.LightGray));

        public static readonly DependencyProperty ButtonBorderColorProperty =
            DependencyProperty.Register("ButtonBorderColor", typeof(Brush), typeof(CircularButtonControl), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty ButtonBorderThicknessProperty =
            DependencyProperty.Register("ButtonBorderThickness", typeof(int), typeof(CircularButtonControl), new PropertyMetadata(2));

        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(string), typeof(CircularButtonControl), new PropertyMetadata(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "image-icon.png")));
        
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register("ImageHeight", typeof(int), typeof(CircularButtonControl), new PropertyMetadata(30));
        
        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register("ImageWidth", typeof(int), typeof(CircularButtonControl), new PropertyMetadata(30));

        public static readonly DependencyProperty ButtonHoverColorProperty =
            DependencyProperty.Register("ButtonHoverColor", typeof(Brush), typeof(CircularButtonControl), new PropertyMetadata(Brushes.LightGray));

        public static readonly DependencyProperty ButtonClickColorProperty =
           DependencyProperty.Register("ButtonClickColor", typeof(Brush), typeof(CircularButtonControl), new PropertyMetadata(Brushes.Gray));

        public event RoutedEventHandler Click;

        protected virtual void OnClick(RoutedEventArgs e)
        {
            Click?.Invoke(this, e);
        }


        public int ImageWidth
        {
            get { return (int)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public int ImageHeight
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        public int Diameter
        {
            get { return (int)GetValue(DiameterProperty); }
            set { SetValue(DiameterProperty, value); }
        }
        
        public int Radius => Diameter / 2;

        public Brush ButtonBackground
        {
            get { return (Brush)GetValue(ButtonBackgroundProperty); }
            set { SetValue(ButtonBackgroundProperty, value); }
        }

        public Brush ButtonBorderColor
        {
            get { return (Brush)GetValue(ButtonBorderColorProperty); }
            set { SetValue(ButtonBorderColorProperty, value); }
        }

        public int ButtonBorderThickness
        {
            get { return (int)GetValue(ButtonBorderThicknessProperty); }
            set { SetValue(ButtonBorderThicknessProperty, value); }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnClick(e); 
        }
    }
}

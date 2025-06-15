using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManager.View.CustomControls.Buttons
{
    /// <summary>
    /// Logika interakcji dla klasy CircularSingleButtonControl.xaml
    /// </summary>
    public partial class CircularSingleButtonControl : UserControl
    {
        private bool buttonsVisible = false;


        public static readonly DependencyProperty SubButtonTextProperty = DependencyProperty.Register("SubButtonText", typeof(string), typeof(CircularSingleButtonControl), new PropertyMetadata("Text"));
        public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register("ButtonWidth", typeof(int), typeof(CircularSingleButtonControl), new PropertyMetadata(160));
        public static readonly DependencyProperty ButtonIsVisibleProperty = DependencyProperty.Register("IsVisible", typeof(Visibility), typeof(CircularSingleButtonControl), new PropertyMetadata(Visibility.Hidden));


        public Visibility ButtonIsVisible
        {
            get { return (Visibility)GetValue(ButtonIsVisibleProperty); }
            set { SetValue(ButtonIsVisibleProperty, value); }
        }

        public string SubButtonText
        {
            get { return (string)GetValue(SubButtonTextProperty); }
            set { SetValue(SubButtonTextProperty, value); }
        }

        public int ButtonWidth
        {
            get { return (int)GetValue(ButtonWidthProperty); }
            set { SetValue(ButtonWidthProperty, value); }
        }


        public CircularSingleButtonControl()
        {
            InitializeComponent();
            buttonCir.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "+-Icon.png");
            buttonCir.Click += ButtonSub_Click;
            SubButton.Visibility = Visibility.Hidden;
        }

        private void buttonCir_Click(object sender, RoutedEventArgs e)
        {
            if (!buttonsVisible)
            {
                AnimateSlideIn(SubButton, SubButtonTransform);
            }
            else
            {
                AnimateSlideOut(SubButton, SubButtonTransform);
            }
            buttonsVisible = !buttonsVisible;
        }

        private void AnimateSlideIn(UIElement element, TranslateTransform transform)
        {
            element.Visibility = Visibility.Visible;

            var anim = new DoubleAnimation
            {
                From = 15,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(100),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };
            transform.BeginAnimation(TranslateTransform.XProperty, anim);
        }

        private void AnimateSlideOut(UIElement element, TranslateTransform transform)
        {
            var anim = new DoubleAnimation
            {
                From = 0,
                To = 15,
                Duration = TimeSpan.FromMilliseconds(100),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseIn }
            };

            anim.Completed += (s, e) => element.Visibility = Visibility.Hidden;

            transform.BeginAnimation(TranslateTransform.XProperty, anim);
        }

        public event RoutedEventHandler ButtonSubClick;

        private void ButtonSub_Click(object sender, RoutedEventArgs e)
        {
            ButtonSubClick?.Invoke(this, e);
        }

    }
}

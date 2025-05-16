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
    /// Logika interakcji dla klasy CircularDoubleButtonControl.xaml
    /// </summary>
    public partial class CircularDoubleButtonControl : UserControl
    {
        private bool buttonsVisible = false;

        public CircularDoubleButtonControl()
        {
            InitializeComponent();

            buttonCir.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "+-Icon.png");
            ButtonTop.Visibility = Visibility.Hidden;
            ButtonBottom.Visibility = Visibility.Hidden;
            ButtonMiddle.Visibility = Visibility.Hidden;

            ButtonTop.Click += ButtonTop_Click;
            ButtonBottom.Click += ButtonBottom_Click;
            ButtonMiddle.Click += ButtonMiddle_Click;
        }

        private void buttonCir_Click(object sender, RoutedEventArgs e)
        {
            if (!buttonsVisible)
            {
                AnimateSlideIn(ButtonTop, TopTransform);
                AnimateSlideIn(ButtonBottom, BottomTransform);
                AnimateSlideIn(ButtonMiddle, MiddleTransform);
            }
            else
            {
                AnimateSlideOut(ButtonTop, TopTransform);
                AnimateSlideOut(ButtonBottom, BottomTransform);
                AnimateSlideOut(ButtonMiddle, MiddleTransform);
            }
            buttonsVisible = !buttonsVisible;
        }


        public event RoutedEventHandler ButtonTopClick;
        public event RoutedEventHandler ButtonBottomClick;
        public event RoutedEventHandler ButtonMiddleClick; 

        private void ButtonTop_Click(object sender, RoutedEventArgs e)
        {
            ButtonTopClick?.Invoke(this, e);
        }

        private void ButtonBottom_Click(object sender, RoutedEventArgs e)
        {
            ButtonBottomClick?.Invoke(this, e);
        }

        private void ButtonMiddle_Click(object sender, RoutedEventArgs e)
        {
            ButtonMiddleClick?.Invoke(this, e);
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



    }
}

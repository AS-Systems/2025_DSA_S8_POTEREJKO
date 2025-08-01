﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace LibraryManager.View.CustomControls.Buttons
{
    /// <summary>
    /// Logika interakcji dla klasy CircularDoubleButtonControl.xaml
    /// </summary>
    public partial class CircularDoubleButtonControl : UserControl
    {
        private bool buttonsVisible = false;

        public static readonly DependencyProperty ButtonTopContentProperty = DependencyProperty.Register("ButtonTopContent", typeof(string), typeof(CircularDoubleButtonControl), new PropertyMetadata("Text"));
        public static readonly DependencyProperty ButtonBottomContentProperty = DependencyProperty.Register("ButtonBottomContent", typeof(string), typeof(CircularDoubleButtonControl), new PropertyMetadata("Text"));

        public string ButtonTopContent
        {
            get { return (string)GetValue(ButtonTopContentProperty); }
            set { SetValue(ButtonTopContentProperty, value); }
        }

        public string ButtonBottomContent
        {
            get { return (string)GetValue(ButtonBottomContentProperty); }
            set { SetValue(ButtonBottomContentProperty, value); }
        }






        public CircularDoubleButtonControl()
        {
            InitializeComponent();

            buttonCir.ImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "+-Icon.png");
            ButtonTop.Visibility = Visibility.Hidden;
            ButtonBottom.Visibility = Visibility.Hidden;

            ButtonTop.Click += ButtonTop_Click;
            ButtonBottom.Click += ButtonBottom_Click;
        }

        private void buttonCir_Click(object sender, RoutedEventArgs e)
        {
            if (!buttonsVisible)
            {
                AnimateSlideIn(ButtonTop, TopTransform);
                AnimateSlideIn(ButtonBottom, BottomTransform);
            }
            else
            {
                AnimateSlideOut(ButtonTop, TopTransform);
                AnimateSlideOut(ButtonBottom, BottomTransform);
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

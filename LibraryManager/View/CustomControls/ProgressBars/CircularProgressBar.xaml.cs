using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace LibraryManager.View.CustomControls.ProgressBars
{
    /// <summary>
    /// Interaction logic for CircularProgressBar.xaml
    /// </summary>
    public partial class CircularProgressBar : UserControl, INotifyPropertyChanged
    {
        public CircularProgressBar()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        // Dependency Properties
        public static readonly DependencyProperty IndicatorBrushProperty =
            DependencyProperty.Register("IndicatorBrush", typeof(Brush), typeof(CircularProgressBar),
                new PropertyMetadata(new BrushConverter().ConvertFrom("#3a3960") as Brush));

        public static readonly DependencyProperty BackgroundIndicatorProperty =
            DependencyProperty.Register("BackgroundIndicator", typeof(Brush), typeof(CircularProgressBar),
                new PropertyMetadata(new BrushConverter().ConvertFrom("#5e686d") as Brush));

        public static readonly DependencyProperty FillValueFontSizeProperty =
            DependencyProperty.Register("FillValueFontSize", typeof(int), typeof(CircularProgressBar),
                new PropertyMetadata(25));

        public static readonly DependencyProperty ArcThicknessProperty =
            DependencyProperty.Register("ArcThickness", typeof(int), typeof(CircularProgressBar),
                new PropertyMetadata(25));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(CircularProgressBar),
                new PropertyMetadata(10, OnValueChanged));

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(CircularProgressBar),
                new PropertyMetadata(15, OnMaxValueChanged));

        // PropertyChanged Callbacks
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (CircularProgressBar)d;
            control.OnPropertyChanged(nameof(FillValueText));
        }

        private static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (CircularProgressBar)d;
            control.OnPropertyChanged(nameof(FillValueText));
        }

        // CLR Properties
        public Brush IndicatorBrush
        {
            get => (Brush)GetValue(IndicatorBrushProperty);
            set => SetValue(IndicatorBrushProperty, value);
        }

        public Brush BackgroundIndicator
        {
            get => (Brush)GetValue(BackgroundIndicatorProperty);
            set => SetValue(BackgroundIndicatorProperty, value);
        }

        public int FillValueFontSize
        {
            get => (int)GetValue(FillValueFontSizeProperty);
            set => SetValue(FillValueFontSizeProperty, value);
        }

        public int ArcThickness
        {
            get => (int)GetValue(ArcThicknessProperty);
            set => SetValue(ArcThicknessProperty, value);
        }

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public int MaxValue
        {
            get => (int)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        // Calculated property
        public string FillValueText => $"{Value}/{MaxValue}";
    }

    [ValueConversion(typeof(object[]), typeof(double))]
    public class ValueAndMaxToAngleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length >= 2 &&
                values[0] is int value &&
                values[1] is int maxValue &&
                maxValue != 0)
            {
                return (double)value / maxValue * 360;
            }

            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            double angle = (double)value;
            return new object[] { Binding.DoNothing, Binding.DoNothing };
        }
    }
}

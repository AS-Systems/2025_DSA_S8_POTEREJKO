using LibraryManager.View.CustomControls.TextBoxes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManager.View.CustomControls.ColumnFilters
{
    /// <summary>
    /// Logika interakcji dla klasy TitleColumnFilter.xaml
    /// </summary>
    public partial class TitleColumnFilter : UserControl
    {

        public static readonly DependencyProperty FilterNameTextProperty = DependencyProperty.Register("FilterNameText", typeof(string), typeof(TitleColumnFilter), new PropertyMetadata(""));
        public static readonly DependencyProperty PlaceholderTextProperty = DependencyProperty.Register("PlaceholderTxt", typeof(string), typeof(TitleColumnFilter), new PropertyMetadata(""));


        public string FilterNameText
        {
            get { return (string)GetValue(FilterNameTextProperty); }
            set { SetValue(FilterNameTextProperty, value); }
        }



        public string PlaceholderTxt
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }






        public TitleColumnFilter()
        {
            InitializeComponent();
            DataContext = this;


            Loaded += (s, e) =>
            {
                var window = Window.GetWindow(this);
                if (window != null)
                {
                    window.LocationChanged += (sender, args) =>
                    {
                        if (PART_Popup != null)
                        {
                            double offset = PART_Popup.HorizontalOffset;
                            PART_Popup.HorizontalOffset = offset + 1;
                            PART_Popup.HorizontalOffset = offset;
                        }
                    };

                    window.SizeChanged += (sender, args) =>
                    {
                        if (PART_Popup != null)
                        {
                            double offset = PART_Popup.HorizontalOffset;
                            PART_Popup.HorizontalOffset = offset + 1;
                            PART_Popup.HorizontalOffset = offset;
                        }
                    };
                }
            };
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            PART_Popup.IsOpen = !PART_Popup.IsOpen;
        }

        public event EventHandler<string> FilterTextChanged;


        private void FilterTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderText.Visibility = string.IsNullOrWhiteSpace(FilterTextBox.Text)
                ? Visibility.Collapsed
                : Visibility.Collapsed;
        }

        private void FilterTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderText.Visibility = string.IsNullOrWhiteSpace(FilterTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void CustomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                PlaceholderText.Visibility = string.IsNullOrWhiteSpace(textBox.Text)
                    ? Visibility.Visible
                    : Visibility.Collapsed;

                FilterTextChanged?.Invoke(this, textBox.Text);
            }
        }



    }
}

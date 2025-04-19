using LibraryManager.View.CustomControls.TextBoxes;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManager.View.CustomControls.ColumnFilters
{
    /// <summary>
    /// Logika interakcji dla klasy TitleColumnFilter.xaml
    /// </summary>
    public partial class TitleColumnFilter : UserControl
    {
        public TitleColumnFilter()
        {
            InitializeComponent();

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
        private void CustomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is CustomTextBox textBox)
            {
                FilterTextChanged?.Invoke(this, textBox.TextBoxText);
            }
        }

    }
}

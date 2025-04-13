using System.Windows;
using System.Windows.Controls;

namespace LibraryManager.View.CustomControls.ColumnFilters
{
    /// <summary>
    /// Logika interakcji dla klasy PageCountColumnFilter.xaml
    /// </summary>
    public partial class PageCountColumnFilter : UserControl
    {
        public PageCountColumnFilter()
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

    }
}

using LibraryManager.Model.Enums;
using LibraryManager.View.CustomControls.Buttons;
using LibraryManager.View.CustomControls.TextBoxes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManager.View.CustomControls.ColumnFilters
{
    /// <summary>
    /// Logika interakcji dla klasy PageCountColumnFilter.xaml
    /// </summary>
    public partial class PageCountColumnFilter : UserControl
    {

        public static readonly DependencyProperty ComparisonOperationProperty = DependencyProperty.Register( nameof(ComparisonOperation), typeof(ComparisonOperation), typeof(PageCountColumnFilter), new PropertyMetadata(ComparisonOperation.Greater));

        public ComparisonOperation ComparisonOperation
        {
            get => (ComparisonOperation)GetValue(ComparisonOperationProperty);
            set => SetValue(ComparisonOperationProperty, value);
        }

        public int Count { get; set; }


        public PageCountColumnFilter()
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

            //PART_Popup.DataContext = this;

        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            PART_Popup.IsOpen = !PART_Popup.IsOpen;
        }

        public event EventHandler<int> FilterTextChanged;
        private void CustomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is SmallTextBox textBox)
            {
                FilterTextChanged?.Invoke(this, textBox.TextBoxText);
                Count = textBox.TextBoxText;
            }
        }

        public event EventHandler<ComparisonOperation> OperationChanged;

        private void OperationButton_OperationChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is ComparisonOperationButtonControl button)
            {
                ComparisonOperation = button.SelectedComparisonOperation;
                OperationChanged?.Invoke(this, button.SelectedComparisonOperation);
            }
        }

    }
}

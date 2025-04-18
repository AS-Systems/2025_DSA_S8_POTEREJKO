using LibraryManager.Model.Enums;
using LibraryManager.View.CustomControls.CheckBox;
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
    /// Logika interakcji dla klasy AvailableColumnFilter.xaml
    /// </summary>
    public partial class AvailableColumnFilter : UserControl
    {



        public bool YesCheckBoxIsChecked
        {
            get { return (bool)GetValue(YesCheckBoxIsCheckedProperty); }
            set { SetValue(YesCheckBoxIsCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckBoxIsChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YesCheckBoxIsCheckedProperty =
            DependencyProperty.Register("YesCheckBoxIsChecked", typeof(bool), typeof(AvailableColumnFilter), new PropertyMetadata(true));

        public bool NoCheckBoxIsChecked
        {
            get { return (bool)GetValue(NoCheckBoxIsCheckedProperty); }
            set { SetValue(NoCheckBoxIsCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckBoxIsChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoCheckBoxIsCheckedProperty =
            DependencyProperty.Register("NoCheckBoxIsChecked", typeof(bool), typeof(AvailableColumnFilter), new PropertyMetadata(true));



        public AvailableColumnFilter()
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
            DataContext = this;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            PART_Popup.IsOpen = !PART_Popup.IsOpen;
        }

        public event EventHandler<SelectedCheckbox?> AvailabilityChanged;

        private void CustomCheckbox_YesCheckedChanged(object sender, RoutedEventArgs e)
        {

            if(sender is CustomCheckbox)
            {
                CustomCheckbox customCheckbox = sender as CustomCheckbox;

                var selections = new SelectedCheckbox();
                selections.YesSelection = customCheckbox.Checked;
                selections.NoSelection = NoCheckBoxIsChecked;

                AvailabilityChanged?.Invoke(this, selections);
            }
        }

        private void CustomCheckbox_NoCheckedChanged(object sender, RoutedEventArgs e)
        {

            if (sender is CustomCheckbox)
            {
                CustomCheckbox customCheckbox = sender as CustomCheckbox;

                var selections = new SelectedCheckbox();
                selections.YesSelection = YesCheckBoxIsChecked;
                selections.NoSelection = customCheckbox.Checked;

                AvailabilityChanged?.Invoke(this, selections);

            }
        }

    }

    public struct SelectedCheckbox
    { 
        public bool? YesSelection;
        public bool? NoSelection;
    }


}

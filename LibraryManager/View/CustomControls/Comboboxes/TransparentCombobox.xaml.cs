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

namespace LibraryManager.View.CustomControls.Comboboxes
{
    /// <summary>
    /// Logika interakcji dla klasy TransparentCombobox.xaml
    /// </summary>
    public partial class TransparentCombobox : UserControl
    {
        public TransparentCombobox()
        {
            InitializeComponent();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedValue = selectedItem.Content?.ToString() ?? "";

                // Raise an event, update a property, or do whatever you want here.
                // Example: 
                SelectionChangedEvent?.Invoke(this, selectedValue);
            }
        }

        // Also declare the event if you want to notify others:

        public event EventHandler<string>? SelectionChangedEvent;

    }
}

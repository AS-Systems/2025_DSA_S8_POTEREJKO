using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManager.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public AddBook()
        {
            InitializeComponent();

            MultiSelectComboBox.ItemsSource = new List<string>
            {
                "Adam Mickiewicz",
                "Henryk Sienkiewicz",
                "Wisława Szymborska",
                "Czesław Miłosz"
            };
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ImageDropControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MultiSelectComboBox_DropDownClosed(object sender, EventArgs e)
        {
            var selectedItems = MultiSelectComboBox.Items.Cast<string>()
                .Where(item =>
                {
                    var container = MultiSelectComboBox.ItemContainerGenerator.ContainerFromItem(item) as ComboBoxItem;
                    return container != null && container.IsSelected;
                });

            MultiSelectComboBox.Text = string.Join(", ", selectedItems);
        }

    }
}

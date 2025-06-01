using LibraryManager.Model.Entities;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace LibraryManager.View.CustomControls.ItemTemplates
{
    /// <summary>
    /// Logika interakcji dla klasy BookshelfItemTemplate.xaml
    /// </summary>
    public partial class BookshelfItemTemplate : UserControl
    {
        private int avaShelfSpace;
        private int allShelfSpace;

        public BookshelfItemTemplate()
        {
            InitializeComponent();
            deleteButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "delete.png");
            infoButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "info.png");
            editButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "edit.png");

            this.Loaded += BookshelfItemTemplate_Loaded;

        }

        private void BookshelfItemTemplate_Loaded(object sender, RoutedEventArgs e)
        {
            var bookshelf = DataContext as Bookshelf;
            if (bookshelf != null)
            {
                avaShelfSpace = 0;
                allShelfSpace = 0;

                var shelves = bookshelf.Shelves;
                
                foreach (var shelf in shelves)
                {
                    avaShelfSpace += shelf.AvailableSpace;
                    allShelfSpace += shelf.Capacity;
                }

                SpaceText.Text = avaShelfSpace.ToString() + "/" + allShelfSpace.ToString();

            }
        }
    }
}

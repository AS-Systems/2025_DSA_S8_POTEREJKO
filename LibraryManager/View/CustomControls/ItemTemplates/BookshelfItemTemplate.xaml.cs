using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
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

        private readonly IBookshelfRepository _bookshelfRepository;

        public static readonly RoutedEvent DeletedEvent = EventManager.RegisterRoutedEvent(
        nameof(Deleted), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BookshelfItemTemplate));

        public event RoutedEventHandler Deleted
        {
            add { AddHandler(DeletedEvent, value); }
            remove { RemoveHandler(DeletedEvent, value); }
        }

        public BookshelfItemTemplate()
        {
            InitializeComponent();
            deleteButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "delete.png");
            infoButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "info.png");
            editButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "edit.png");

            Loaded += BookshelfItemTemplate_Loaded;

            _bookshelfRepository = App.ServiceProvider.GetRequiredService<IBookshelfRepository>();
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

        private void infoButton_ItemClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is Bookshelf bookshelf)
            { 
                //Info Bookshelf page
            }
        }

        private void editButton_ItemClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is Bookshelf bookshelf)
            {
                //Edit Bookshelf page
            }
        }

        private async void deleteButton_ItemClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is Bookshelf bookshelf)
            {
                string message = $"Are you sure you want to delete: {bookshelf.Name} with: {bookshelf.Shelves.Count} shelves?";
               
                var result = MessageBox.Show(message, "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);


                if (result == MessageBoxResult.Yes)
                {
                    // Perform the delete logic here
                    await _bookshelfRepository.DeleteAsync(bookshelf);
                    var clicked = MessageBox.Show("Item deleted successfully!", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);

                    RaiseEvent(new RoutedEventArgs(DeletedEvent));
                }
            }
        }
    }
}

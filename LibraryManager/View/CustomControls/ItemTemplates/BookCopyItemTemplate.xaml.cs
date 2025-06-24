using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories;
using LibraryManager.View.Windows;
using LibraryManager.View.Windows.Edit;
using LibraryManager.View.Windows.Info;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManager.View.CustomControls.ItemTemplates
{
    /// <summary>
    /// Logika interakcji dla klasy BookCopyItemTemplate.xaml
    /// </summary>
    public partial class BookCopyItemTemplate : UserControl
    {
        private readonly IBookCopyRepository _bookCopyRepository;

        public static readonly RoutedEvent DeletedEvent = EventManager.RegisterRoutedEvent(
        nameof(Deleted), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BookCopyItemTemplate));

        public event RoutedEventHandler Deleted
        {
            add { AddHandler(DeletedEvent, value); }
            remove { RemoveHandler(DeletedEvent, value); }
        }


        public BookCopyItemTemplate()
        {
            InitializeComponent();
            deleteButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "delete.png");
            infoButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "info.png");
            editButton.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "edit.png");

            _bookCopyRepository = App.ServiceProvider.GetRequiredService<IBookCopyRepository>();

            Loaded += BookCopyItemTemplate_Loaded;
        }

        private void BookCopyItemTemplate_Loaded(object sender, RoutedEventArgs e)
        {
            var bookCopy = DataContext as BookCopy;
            if (bookCopy != null)
            {


            }
        }



        private void infoButton_ItemClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is BookCopy bookCopy)
            {
                var window = new InfoBookCopy(bookCopy);
                window.Owner = Window.GetWindow(this);
                window.ShowDialog();
            }
        }

        private async void editButton_ItemClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is BookCopy bookCopy)
            {
                var window = new EditBookCopy(bookCopy);
                window.Owner = Window.GetWindow(this);
                await window.LoadDataAsync();

                var result = window.ShowDialog();

                RaiseEvent(new RoutedEventArgs(DeletedEvent));
            }
        }

        private async void deleteButton_ItemClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is BookCopy bookCopy)
            {
                string message = $"Are you sure you want to delete: {bookCopy.Book.Title} book copy?";

                var result = MessageBox.Show(message, "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);


                if (result == MessageBoxResult.Yes)
                {
                    // Perform the delete logic here
                    await _bookCopyRepository.DeleteBookCopyAsync(bookCopy.Id);
                    var clicked = MessageBox.Show("Item deleted successfully!", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);

                    RaiseEvent(new RoutedEventArgs(DeletedEvent));
                }
            }
        }

    }
}

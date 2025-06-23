using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using LibraryManager.Model.Repositories;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManager.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AdddBorrow.xaml
    /// </summary>
    public partial class AdddBorrow : Window
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBookCopyRepository _bookCopyRepository;

        public AdddBorrow()
        {
            InitializeComponent();
            _borrowRepository = App.ServiceProvider.GetRequiredService<IBorrowRepository>();
            _bookRepository = App.ServiceProvider.GetRequiredService<IBookRepository>();
            _bookCopyRepository = App.ServiceProvider.GetRequiredService<IBookCopyRepository>();

            DataContext = this;

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedBorrowDate = borrowDateBox.SelectedDate;
            var selectedReturnDate = returnDateBox.SelectedDate;

            if (selectedBorrowDate > selectedReturnDate && selectedBorrowDate > DateTime.Now)
            { 
                MessageBox.Show("Return date cant be before borrow!", "Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }

            var selectedBook = bookBox.SelectedItem;

            if (selectedBook is null)
            {
                MessageBox.Show("No book selected!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            var selectedBookCopy = bookCopyBox.SelectedItem;
            
            if (selectedBook is null)
            {
                MessageBox.Show("No book copy selected!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            if (selectedBorrowDate is not null || selectedReturnDate is not null || selectedBook is not null || selectedBookCopy is not null || selectedBorrowDate > selectedReturnDate)
            {
                var borrow = new Borrow
                {
                    ReturnDate = selectedReturnDate.Value,
                    BorrowDate = selectedBorrowDate.Value,
                    BookCopy = (BookCopy)selectedBookCopy,
                    Status = (sbyte)Status.Upcomming,
                    User = AppUser.User
                };

                await _borrowRepository.InsertAsync(borrow);

                DialogResult = true;

            }
            else 
            {
                DialogResult = false;
            }


        }


        public async Task LoadDataAsync()
        { 
            var books = await _bookRepository.GetAllBooksAsync();
            bookBox.ItemsSource = books;
        
        }

        private async void bookBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedBook = bookBox.SelectedItem as Book;

            if (selectedBook is not null)
            {
                var bookCopyList = await _bookCopyRepository.GetBookCopiesOfBook(selectedBook.Id);

                bookCopyBox.ItemsSource = null;
                bookCopyBox.Items.Clear();

                bookCopyBox.ItemsSource = bookCopyList;
            }


        }
    }
}

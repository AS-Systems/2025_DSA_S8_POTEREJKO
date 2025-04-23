using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.View.CustomControls.Buttons;
using LibraryManager.View.CustomControls.ColumnFilters;
using LibraryManager.View.Windows.Edit;
using LibraryManager.View.Windows.Info;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
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

namespace LibraryManager.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Book> FilteredBooks { get; set; } = new ObservableCollection<Book>();
        private List<Book> AllBooks { get; set; } = new List<Book>();
        private readonly IBookRepository _bookRepository;

        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set { selectedBook = value;
                OnPropertyChanged();
                ActivateItemActionButtons();
            }
        }



        public BooksPage()
        {
            InitializeComponent();
            _bookRepository = App.ServiceProvider.GetRequiredService<IBookRepository>();

            ActivateItemActionButtons();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TitleColumnFilter_FilterTextChanged(object sender, string filterText)
        {
            var filtered = AllBooks
            .Where(b => b.Title.Contains(filterText, StringComparison.OrdinalIgnoreCase))
            .ToList();

            FilteredBooks.Clear();
            foreach (var book in filtered)
            {
                FilteredBooks.Add(book);
            }
        }

        private void AuthorColumnFilter_FilterTextChanged(object sender, string filterText)
        {
            var filtered = AllBooks
           .Where(b => (b.Author.Name+b.Author.Surname).Contains(filterText, StringComparison.OrdinalIgnoreCase))
           .ToList();

            FilteredBooks.Clear();
            foreach (var book in filtered)
            {
                FilteredBooks.Add(book);
            }
        }

        private void PageCountColumnFilter_FilterTextChanged(object sender, int pageCount)
        {
            var operation = ((PageCountColumnFilter)sender).ComparisonOperation;

            List<Book> filtered = operation switch
            {
                ComparisonOperation.Equal => AllBooks.Where(b => b.PageCount == pageCount).ToList(),
                ComparisonOperation.Greater => AllBooks.Where(b => b.PageCount > pageCount).ToList(),
                ComparisonOperation.GreaterOrEqual => AllBooks.Where(b => b.PageCount >= pageCount).ToList(),
                ComparisonOperation.Lower => AllBooks.Where(b => b.PageCount < pageCount).ToList(),
                ComparisonOperation.LowerOrEqual => AllBooks.Where(b => b.PageCount <= pageCount).ToList(),
                _ => AllBooks
            };

            FilteredBooks.Clear();
            foreach (var book in filtered)
            {
                FilteredBooks.Add(book);
            }
        }

        private void PageCountColumnFilter_OperationChanged(object sender, ComparisonOperation operation)
        {
            var pageCount = ((PageCountColumnFilter)sender).Count;
            List<Book> filtered = operation switch
            {
                ComparisonOperation.Equal => AllBooks.Where(b => b.PageCount == pageCount).ToList(),
                ComparisonOperation.Greater => AllBooks.Where(b => b.PageCount > pageCount).ToList(),
                ComparisonOperation.GreaterOrEqual => AllBooks.Where(b => b.PageCount >= pageCount).ToList(),
                ComparisonOperation.Lower => AllBooks.Where(b => b.PageCount < pageCount).ToList(),
                ComparisonOperation.LowerOrEqual => AllBooks.Where(b => b.PageCount <= pageCount).ToList(),
                _ => AllBooks
            };

            FilteredBooks.Clear();
            foreach (var book in filtered)
            {
                FilteredBooks.Add(book);
            }
        }

        private void AvailableColumnFilter_AvailabilityChanged(object sender, SelectedCheckbox? e)
        {
            var noCheckboxValue = e.Value.NoSelection;
            var yesCheckboxValue = e.Value.YesSelection;
            List<Book> filtered = new List<Book>();


            if (noCheckboxValue != null && yesCheckboxValue != null)
            {
                if (noCheckboxValue == true && yesCheckboxValue == true)
                {
                    filtered = AllBooks;
                }
                else if (yesCheckboxValue == true && noCheckboxValue == false)
                {
                    filtered = AllBooks.Where(b => b.Bookcopies.Any(c => c.IsAvailable == true)).ToList();
                }
                else if (yesCheckboxValue == false && noCheckboxValue == true)
                {
                    filtered = AllBooks.Where(b => b.Bookcopies.Any(c => c.IsAvailable == false)).ToList();
                }
            }

            FilteredBooks.Clear();
            foreach (var book in filtered)
                FilteredBooks.Add(book);
        }

        public async Task LoadDataAsync()
        {
            AllBooks = await _bookRepository.GetAllBooksAsync();
            FilteredBooks.Clear();
            foreach (var book in AllBooks)
            {
                FilteredBooks.Add(book);
            }

        }

        private void ActivateItemActionButtons()
        {
            if (selectedBook == null)
            {
                ItemInfo.IsEnabled = false;
                ItemEdit.IsEnabled = false;
                ItemDelete.IsEnabled = false;
            }
            else
            {
                ItemInfo.IsEnabled = true;
                ItemEdit.IsEnabled = true;
                ItemDelete.IsEnabled = true;
            }
        }

        private void ItemInfo_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (selectedBook != null)
            {
                var infoWindow = new InfoBook(selectedBook);
                infoWindow.ShowDialog();
            }
        }

        private void ItemEdit_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (selectedBook != null)
            {
                var editWindow = new EditBook(selectedBook);
                editWindow.ShowDialog();
            }
        }

        private void ItemDelete_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (selectedBook != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete: {selectedBook.Title}", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    // Perform the delete logic here
                    MessageBox.Show("Item deleted successfully!", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            


        }
    }


}

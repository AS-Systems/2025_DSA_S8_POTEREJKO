using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.Services;
using LibraryManager.View.CustomControls.ColumnFilters;
using LibraryManager.View.Windows;
using LibraryManager.View.Windows.Edit;
using LibraryManager.View.Windows.Info;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LibraryManager.Services;
using System.Windows.Input;

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
            set
            {
                selectedBook = value;
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

        private void authorColumnFilter_FilterTextChanged(object sender, string filterText)
        {
            var filtered = AllBooks
           .Where(b => b.BookAuthors.Any(ba => ba.Author.DisplayName.Contains(filterText, StringComparison.OrdinalIgnoreCase)))
           .ToList();

            FilteredBooks.Clear();
            foreach (var book in filtered)
            {
                FilteredBooks.Add(book);
            }
        }

        private void genreColumnFilter_FilterTextChanged(object sender, string filterText)
        {
            var filtered = AllBooks
           .Where(b => b.BooksGenres.Any(bg => bg.Genre.DisplayName.Contains(filterText, StringComparison.OrdinalIgnoreCase)))
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
                    filtered = AllBooks.Where(b => b.BookCopies.Any(c => c.IsAvailable == true)).ToList();
                }
                else if (yesCheckboxValue == false && noCheckboxValue == true)
                {
                    filtered = AllBooks.Where(b => b.BookCopies.Any(c => c.IsAvailable == false)).ToList();
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
                infoWindow.Owner = Window.GetWindow(this);
                infoWindow.ShowDialog();
            }
        }

        private async void ItemEdit_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (selectedBook != null)
            {
                var editWindow = new EditBook(selectedBook);
                editWindow.Owner = Window.GetWindow(this);
                await editWindow.LoadDataAsync();

                var result = editWindow.ShowDialog();

                if (result == true)
                {
                    await LoadDataAsync();
                }

            }
        }

        private async void ItemDelete_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (selectedBook != null)
            {

                var result = System.Windows.MessageBox.Show($"Are you sure you want to delete: {selectedBook.Title}", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    await _bookRepository.DeleteAsync(selectedBook);

                    // Perform the delete logic here
                    System.Windows.MessageBox.Show("Item deleted successfully!", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    await LoadDataAsync();
                }
            }
        }

        private async void CircularDoubleButtonControl_ButtonBottomClick(object sender, RoutedEventArgs e)
        {
            var addBookWindow = new AddBook();
            addBookWindow.Owner = Window.GetWindow(this);
            await addBookWindow.LoadDataAsync();

            var result = addBookWindow.ShowDialog();
            if (result == true)
            {
                await LoadDataAsync();
            }
        }

        private void CircularDoubleButtonControl_ButtonTopClick(object sender, RoutedEventArgs e)
        {
            var addAuthorWindow = new AddAuthor();
            addAuthorWindow.Owner = Window.GetWindow(this);

            addAuthorWindow.ShowDialog();
        }

        private async void CircularDoubleButtonControl_ButtonMiddleClick(object sender, RoutedEventArgs e)
        {
            var addBookWindow = new AddBook();
            addBookWindow.Owner = Window.GetWindow(this);
            await addBookWindow.LoadDataAsync();

            var result = addBookWindow.ShowDialog();

            if (result == true)
            {
                await LoadDataAsync();
            }
        }

        private void Title_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("This is the title of the book.");
        }

        private void Authors_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("These are the authors of the book.");
        }

        private void Genres_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("These are the genres of the book.");
        }

        private void Page_Cnt_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("This is the number of pages in the book.");
        }

        private void Available_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("This indicates whether the book is available for borrowing.");
        }

        private void Info_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click to view more information about the book.");
        }

        private void Edit_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click to edit the book details.");
        }

        private void Delete_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click to delete the book.");
        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("Click to add a new book or author.");
        }

        private void Field_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ClippyService.IsVisible)
                ClippyService.Say("You can hover over the fields to get more information.");
        }

    }


}

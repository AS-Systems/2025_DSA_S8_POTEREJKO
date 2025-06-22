using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace LibraryManager.View.Windows.Edit
{
    /// <summary>
    /// Logika interakcji dla klasy EditBook.xaml
    /// </summary>
    public partial class EditBook : Window
    {
        public ObservableCollection<Genre> Genres { get; set; } = new();
        public ObservableCollection<Genre> SelectedGenres { get; set; } = new();

        public ObservableCollection<Author> Authors { get; set; } = new();
        public ObservableCollection<Author> SelectedAuthors { get; set; } = new();

        private Book _book;

        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;


        public EditBook(Book book)
        {
            InitializeComponent();

            coverHolder.ImageBlob = book.Cover;
            titleBox.Text = book.Title;
            descriptionBox.Text = book.Description; 
            pageNumBox.Text = book.PageCount.ToString();
            ibanBox.Text = book.Iban.ToString();
            
            _book = book;

            DataContext = this;
            _genreRepository = App.ServiceProvider.GetRequiredService<IGenreRepository>();
            _authorRepository = App.ServiceProvider.GetRequiredService<IAuthorRepository>();
            _bookRepository = App.ServiceProvider.GetRequiredService<IBookRepository>();


        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void ImageDropControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<BooksGenre> newBooksGenre = new();
            List<BookAuthor> newBookAuthor = new();

            if (SelectedGenres.Count > 0 && SelectedAuthors.Count > 0)
            {
                _book.Iban = int.Parse(ibanBox.Text);
                _book.Title = titleBox.Text;
                _book.Description = descriptionBox.Text;
                _book.Cover = coverHolder.ImageBlob;
                _book.PageCount = int.Parse(pageNumBox.Text);

                foreach (var genre in SelectedGenres)
                {
                    newBooksGenre.Add(new BooksGenre
                    {
                        Book = _book,
                        Genre = genre,
                    }
                    );
                }
                _book.BooksGenres = newBooksGenre;

                foreach (var author in SelectedAuthors)
                {
                    newBookAuthor.Add(new BookAuthor
                    {
                        Book = _book,
                        Author = author,
                    }
                    );
                }

                _book.BookAuthors = newBookAuthor;

                await _bookRepository.UpdateAsync(_book);
                MessageBox.Show("Book updated!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                DialogResult = true;
            }
            else 
            {
                DialogResult = false;
            }

        }




        public async Task LoadDataAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            var authors = await _authorRepository.GetAllAuthorsAsync();

            Genres.Clear();
            foreach (var genre in genres)
            {
                Genres.Add(genre);
            }

            Authors.Clear();
            foreach (var author in authors)
            {
                Authors.Add(author);
            }


            foreach (var genre in _book.BooksGenres)
            {
                SelectedGenres.Add(genre.Genre);
            }

            foreach (var author in _book.BookAuthors)
            {
                SelectedAuthors.Add(author.Author);
            }



            authorBox.ForceUpdateSelection();
            genreBox.ForceUpdateSelection();

        }


    }
}

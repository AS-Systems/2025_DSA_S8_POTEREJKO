using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
        public ObservableCollection<Genre> Genres { get; set; } = new();
        public ObservableCollection<Genre> SelectedGenres { get; set; } = new();

        public ObservableCollection<Author> Authors { get; set; } = new();
        public ObservableCollection<Author> SelectedAuthors { get; set; } = new();

        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public AddBook()
        {
            InitializeComponent();
            DataContext = this;
            _genreRepository = App.ServiceProvider.GetRequiredService<IGenreRepository>();
            _authorRepository = App.ServiceProvider.GetRequiredService<IAuthorRepository>();
            _bookRepository = App.ServiceProvider.GetRequiredService<IBookRepository>();    

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ImageDropControl_Loaded(object sender, RoutedEventArgs e)
        {

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

        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGenres.Count > 0 && SelectedAuthors.Count > 0)
            {
                var newBook = new Book
                {
                    Title = titleBox.Text,
                    PageCount = int.Parse(pageNumBox.Text),
                    Description = descriptionBox.Text,
                    Cover = coverHolder.ImageBlob,
                };

                foreach (var genre in SelectedGenres)
                {
                    newBook.BooksGenres.Add(new BooksGenre
                    { 
                        Book = newBook,
                        Genre = genre,
                    }
                    );
                }

                foreach (var author in SelectedAuthors)
                {
                    newBook.BookAuthors.Add(new BookAuthor 
                    { 
                        Book = newBook,
                        Author = author,
                    }
                    );
                }

                await _bookRepository.InsertAsync(newBook);
                MessageBox.Show("Book added!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                DialogResult = true;
            }
        }
    }
}

using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logika interakcji dla klasy HomePage.xaml
    /// </summary>
    public partial class HomePage : Page, INotifyPropertyChanged
    {
        private readonly IBookRepository _bookRepository;
        private readonly User _appUser;
        public event PropertyChangedEventHandler? PropertyChanged;


        #region Private-Properties

        private int allBooks;
        private int allAvailableBooks;
        private int yourBooks;
        private int availableYourBooks;
        private int totalBorrows;
        private int upcomingBorrows;
        private int upcomingReturns;

        

        #endregion

        #region Public-Properties
        public int AllBooks
        {
            get { return allBooks; }
            set { allBooks = value;
                OnPropertyChanged();
            }
        }

        public int AllAvailableBooks
        {
            get { return allAvailableBooks; }
            set { allAvailableBooks = value;
                OnPropertyChanged();
            }
        }

        public int YourBooks
        {
            get { return yourBooks; }
            set { yourBooks = value;
                OnPropertyChanged();
            }
        }

        public int AvailableYourBooks
        {
            get { return availableYourBooks; }
            set { availableYourBooks = value;
                OnPropertyChanged();
            }
        }

        public int TotalBorrows
        {
            get { return totalBorrows; }
            set { totalBorrows = value;
                OnPropertyChanged();
            }
        }

        public int UpcomingBorrows
        {
            get { return upcomingBorrows; }
            set { upcomingBorrows = value;
                OnPropertyChanged();
            }
        }

        public int UpcomingReturns
        {
            get { return upcomingReturns; }
            set { upcomingReturns = value;
                OnPropertyChanged();
            }
        }

        #endregion


        public HomePage(User appUser)
        {
            InitializeComponent();
            _appUser = appUser;
            _bookRepository = App.ServiceProvider.GetRequiredService<IBookRepository>();         
            DataContext = this;


            TotalBorrows = 20;

            AllAvailableBooks = 65;
            AllBooks = 80;
            
            AvailableYourBooks = 3;
            YourBooks = 7;

            UpcomingBorrows = 2;
            UpcomingReturns = 1;
            _ = LoadDataAsync();
        }


        public async Task LoadDataAsync()
    {
        try
        {
            var allBooksList = await _bookRepository.GetAllBooksAsync();
            var availableBooksList = await _bookRepository.GetAllAvailableBooksAsync();
            var userBooksList = await _bookRepository.GetAllBooksOfUserAsync(_appUser.Id);
            var availableUserBooksList = await _bookRepository.GetAllAvailableBooksOfUserAsync(_appUser.Id);

            AllBooks = allBooksList.Count;
            AllAvailableBooks = availableBooksList.Count;
            YourBooks = userBooksList.Count;
            AvailableYourBooks = availableUserBooksList.Count;

            // For now, mock values or call the corresponding methods (later)
            TotalBorrows = 0;
            UpcomingBorrows = 0;
            UpcomingReturns = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to load data: {ex.Message}");
        }
    }



        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

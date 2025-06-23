using LibraryManager.Model.Entities;
using LibraryManager.Model.Enums;
using LibraryManager.Model.Repositories;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace LibraryManager.View.CustomControls.ItemTemplates
{
    /// <summary>
    /// Logika interakcji dla klasy BorrowCycleItemTemplate.xaml
    /// </summary>
    public partial class BorrowCycleItemTemplate : UserControl
    {
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly IBorrowRepository _borrowRepository;


        public static readonly RoutedEvent DeletedEvent = EventManager.RegisterRoutedEvent(
        nameof(Deleted), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BorrowCycleItemTemplate));

        public event RoutedEventHandler Deleted
        {
            add { AddHandler(DeletedEvent, value); }
            remove { RemoveHandler(DeletedEvent, value); }
        }



        public static readonly DependencyProperty IsBookReturnProperty = DependencyProperty.Register("IsBookReturn", typeof(bool), typeof(BorrowCycleItemTemplate), new PropertyMetadata(true));
        public bool IsBookReturn
        {
            get { return (bool)GetValue(IsBookReturnProperty); }
            set { SetValue(IsBookReturnProperty, value); }
        }

        public BorrowCycleItemTemplate()
        {
            InitializeComponent();
            _bookCopyRepository = App.ServiceProvider.GetRequiredService<IBookCopyRepository>();
            _borrowRepository = App.ServiceProvider.GetRequiredService<IBorrowRepository>();    

            Loaded += BorrowItemTemplate_Loaded;
        }


        private void BorrowItemTemplate_Loaded(object sender, RoutedEventArgs e)
        {
            var borrow = DataContext as Borrow;
            DateTime date;

            if (IsBookReturn)
            {
                actionBtn.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "downward.png");
            }
            else
            {
                actionBtn.IconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "upward.png");
            }


            if (borrow is null)
            {
                return;
            }

            if (IsBookReturn)
            {
                date = borrow.ReturnDate;
            }
            else {
                date = borrow.BorrowDate;
            }

            dateText.Text = (date.ToShortDateString() + $" {date.Hour}:{date.Minute}");
        }

        private async void actionBtn_ItemClicked(object sender, RoutedEventArgs e)
        {
            var selectedBorrow = DataContext as Borrow;

            if (selectedBorrow is null)
            {
                return;
            }

            if (IsBookReturn)
            {
                var finishedBorrow = selectedBorrow;

                finishedBorrow.ReturnDate = DateTime.Now;
                finishedBorrow.Status = (sbyte)Status.Finished;

                var bookCopy = finishedBorrow.BookCopy;
                bookCopy.IsAvailable = true;

                await _borrowRepository.UpdateAsync(finishedBorrow);
                await _bookCopyRepository.UpdateBookCopyAsync(bookCopy);

                RaiseEvent(new RoutedEventArgs(DeletedEvent));

                MessageBox.Show($"Book {bookCopy.Book.Title} was returned successfully!","Info",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else 
            {
                var startingBorrow = selectedBorrow;

                startingBorrow.BorrowDate = DateTime.Now;
                startingBorrow.Status = (sbyte)Status.Current;

                var bookCopy = startingBorrow.BookCopy;
                bookCopy.IsAvailable = false;

                await _borrowRepository.UpdateAsync(startingBorrow);
                await _bookCopyRepository.UpdateBookCopyAsync(bookCopy);

                RaiseEvent(new RoutedEventArgs(DeletedEvent));

                MessageBox.Show($"Book {bookCopy.Book.Title} was issued successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }



        }
    }
}

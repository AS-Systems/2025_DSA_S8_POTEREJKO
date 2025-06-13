using LibraryManager.Model.Entities;
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

        public static readonly DependencyProperty IsBookReturnProperty = DependencyProperty.Register("IsBookReturn", typeof(bool), typeof(BorrowCycleItemTemplate), new PropertyMetadata(true));
        public bool IsBookReturn
        {
            get { return (bool)GetValue(IsBookReturnProperty); }
            set { SetValue(IsBookReturnProperty, value); }
        }

        public BorrowCycleItemTemplate()
        {
            InitializeComponent();

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


    }
}

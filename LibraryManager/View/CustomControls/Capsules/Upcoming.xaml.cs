using System;
using System.Collections.Generic;
using System.Linq;
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
using LibraryManager.Model.Enums;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.View.CustomControls.Capsules
{
    /// <summary>
    /// Logika interakcji dla klasy Upcoming.xaml
    /// </summary>
    public partial class Upcoming : UserControl
    {
        
        private readonly IBorrowRepository _borrowRepository;
        public Upcoming()
        {
            InitializeComponent();
            _borrowRepository = App.ServiceProvider.GetRequiredService<IBorrowRepository>();
        }

        public static readonly DependencyProperty CapsuleWidthProperty = DependencyProperty.Register("CapsuleWidth", typeof(int), typeof(Upcoming), new PropertyMetadata(250));
        public static readonly DependencyProperty CapsuleHeightProperty = DependencyProperty.Register("CapsuleHeight", typeof(int), typeof(Upcoming), new PropertyMetadata(350));
        public static readonly DependencyProperty HeaderTopFontSizeProperty = DependencyProperty.Register("HeaderTopFontSize", typeof(int), typeof(Upcoming), new PropertyMetadata(39));
        public static readonly DependencyProperty HeaderBottomFontSizeProperty = DependencyProperty.Register("HeaderBottomFontSize", typeof(int), typeof(Upcoming), new PropertyMetadata(35));
        public static readonly DependencyProperty CapsuleCornerRadiusProperty = DependencyProperty.Register("CapsuleCornerRadius", typeof(int), typeof(Upcoming), new PropertyMetadata(65));
        public static readonly DependencyProperty BorrowsReturnsFontSizeProperty = DependencyProperty.Register("BorrowsReturnsFontSize", typeof(int), typeof(Upcoming), new PropertyMetadata(40));
        public static readonly DependencyProperty ActionFontSizeProperty = DependencyProperty.Register("ActionFontSize", typeof(int), typeof(Upcoming), new PropertyMetadata(20));
        public static readonly DependencyProperty BorrowCountProperty = DependencyProperty.Register("BorrowCount", typeof(string), typeof(Upcoming), new PropertyMetadata("8"));
        public static readonly DependencyProperty ReturnCountProperty = DependencyProperty.Register("ReturnCount", typeof(string), typeof(Upcoming), new PropertyMetadata("5"));

        public int CapsuleWidth
        {
            get { return (int)GetValue(CapsuleWidthProperty); }
            set { SetValue(CapsuleWidthProperty, value); }
        }

        public int CapsuleHeight
        {
            get { return (int)GetValue(CapsuleHeightProperty); }
            set { SetValue(CapsuleHeightProperty, value); }
        }

        public int HeaderTopFontSize
        {
            get { return (int)GetValue(HeaderTopFontSizeProperty); }
            set { SetValue(HeaderTopFontSizeProperty, value); }
        }

        public int HeaderBottomFontSize
        {
            get { return (int)GetValue(HeaderBottomFontSizeProperty); }
            set { SetValue(HeaderBottomFontSizeProperty, value); }
        }

        public int CapsuleCornerRadius
        {
            get { return (int)GetValue(CapsuleCornerRadiusProperty); }
            set { SetValue(CapsuleCornerRadiusProperty, value); }
        }

        public int BorrowsReturnsFontSize
        {
            get { return (int)GetValue(BorrowsReturnsFontSizeProperty); }
            set { SetValue(BorrowsReturnsFontSizeProperty, value); }
        }

        public int ActionFontSize
        {
            get { return (int)GetValue(ActionFontSizeProperty); }
            set { SetValue(ActionFontSizeProperty, value); }
        }

        public string BorrowCount
        {
            get { return (string)GetValue(BorrowCountProperty); }
            set { SetValue(BorrowCountProperty, value); }
        }

        public string ReturnCount
        {
            get { return (string)GetValue(ReturnCountProperty); }
            set { SetValue(ReturnCountProperty, value); }
        }

        // Define a routed event or simple CLR event to notify selection changed
        public event EventHandler<string>? SelectionChangedEvent;

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedValue = selectedItem.Content.ToString() ?? "";

                // Raise selection event
                SelectionChangedEvent?.Invoke(this, selectedValue);

                // Parse TimePeriod
                TimePeriod period = selectedValue switch
                {
                    "Year" => TimePeriod.ThisYear,
                    "Month" => TimePeriod.ThisMonth,
                    "Day" => TimePeriod.Today,
                    _ => TimePeriod.Today
                };

                // Fetch upcoming borrows
                var upcomingBorrows = await _borrowRepository.GetUpcomingBorrowsAsync(period);

                // Fetch upcoming returns (you may need to add GetUpcomingReturnsAsync)
                var upcomingReturns = await _borrowRepository.GetUpcomingReturnsAsync(period);

                // Update dependency properties
                BorrowCount = upcomingBorrows.Count().ToString();
                ReturnCount = upcomingReturns.Count().ToString();
            }
        }


    }
}

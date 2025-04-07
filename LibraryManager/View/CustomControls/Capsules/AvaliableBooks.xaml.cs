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

namespace LibraryManager.View.CustomControls.Capsules
{
    /// <summary>
    /// Logika interakcji dla klasy AvaliableBooks.xaml
    /// </summary>
    public partial class AvaliableBooks : UserControl
    {
        public AvaliableBooks()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CapsuleWidthProperty = DependencyProperty.Register("CapsuleWidth", typeof(int), typeof(AvaliableBooks), new PropertyMetadata(250));
        public static readonly DependencyProperty CapsuleHeightProperty = DependencyProperty.Register("CapsuleHeight", typeof(int), typeof(AvaliableBooks), new PropertyMetadata(350));
        public static readonly DependencyProperty YourBooksMaxProperty = DependencyProperty.Register("YourBooksMax", typeof(int), typeof(AvaliableBooks), new PropertyMetadata(50));
        public static readonly DependencyProperty YourBooksAvaliableProperty = DependencyProperty.Register("YourBooksAvaliable", typeof(int), typeof(AvaliableBooks), new PropertyMetadata(37));
        public static readonly DependencyProperty AllBooksMaxProperty = DependencyProperty.Register("AllBooksMax", typeof(int), typeof(AvaliableBooks), new PropertyMetadata(70));
        public static readonly DependencyProperty AllBooksAvaliableProperty = DependencyProperty.Register("AllBooksAvaliable", typeof(int), typeof(AvaliableBooks), new PropertyMetadata(53));
        public static readonly DependencyProperty HeaderTopFontSizeProperty = DependencyProperty.Register("HeaderTopFontSize", typeof(int), typeof(AvaliableBooks), new PropertyMetadata(35));
        public static readonly DependencyProperty HeaderBottomFontSizeProperty = DependencyProperty.Register("HeaderBottomFontSize", typeof(int), typeof(AvaliableBooks), new PropertyMetadata(35));
        public static readonly DependencyProperty CapsuleCornerRadiusProperty = DependencyProperty.Register("CapsuleCornerRadius", typeof(int), typeof(AvaliableBooks), new PropertyMetadata(65));


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

        public int YourBooksMax
        {
            get { return (int)GetValue(YourBooksMaxProperty); }
            set { SetValue(YourBooksMaxProperty, value); }
        }

        public int AllBooksMax
        {
            get { return (int)GetValue(AllBooksMaxProperty); }
            set { SetValue(AllBooksMaxProperty, value); }
        }

        public int YourBooksAvaliable
        {
            get { return (int)GetValue(YourBooksAvaliableProperty); }
            set { SetValue(YourBooksAvaliableProperty, value); }
        }

        public int AllBooksAvaliable
        {
            get { return (int)GetValue(AllBooksAvaliableProperty); }
            set { SetValue(AllBooksAvaliableProperty, value); }
        }

    }
}

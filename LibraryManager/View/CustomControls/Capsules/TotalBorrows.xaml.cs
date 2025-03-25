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
    /// Logika interakcji dla klasy TotalBorrows.xaml
    /// </summary>
    public partial class TotalBorrows : UserControl
    {
        public TotalBorrows()
        {
            InitializeComponent();
        }


        public static readonly DependencyProperty CapsuleWidthProperty = DependencyProperty.Register("CapsuleWidth", typeof(int), typeof(TotalBorrows), new PropertyMetadata(250));
        public static readonly DependencyProperty CapsuleHeightProperty = DependencyProperty.Register("CapsuleHeight", typeof(int), typeof(TotalBorrows), new PropertyMetadata(350));
        public static readonly DependencyProperty TotalCountTextProperty = DependencyProperty.Register("TotalCountText", typeof(string), typeof(TotalBorrows), new PropertyMetadata("00"));
        public static readonly DependencyProperty TotalCountTextFontSizeProperty = DependencyProperty.Register("TotalCountTextFontSize", typeof(int), typeof(TotalBorrows), new PropertyMetadata(160));
        public static readonly DependencyProperty HeaderTopFontSizeProperty = DependencyProperty.Register("HeaderTopFontSize", typeof(int), typeof(TotalBorrows), new PropertyMetadata(45));
        public static readonly DependencyProperty HeaderBottomFontSizeProperty = DependencyProperty.Register("HeaderBottomFontSize", typeof(int), typeof(TotalBorrows), new PropertyMetadata(35));
        public static readonly DependencyProperty CapsuleCornerRadiusProperty = DependencyProperty.Register("CapsuleCornerRadius", typeof(int), typeof(TotalBorrows), new PropertyMetadata(65));


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

        public string TotalCountText
        {
            get { return (string)GetValue(TotalCountTextProperty); }
            set { SetValue(TotalCountTextProperty, value); }
        }

        public int TotalCountTextFontSize
        {
            get { return (int)GetValue(TotalCountTextFontSizeProperty); }
            set { SetValue(TotalCountTextFontSizeProperty, value); }
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



    }
}

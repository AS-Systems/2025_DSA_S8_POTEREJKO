using LibraryManager.Model.Enums;
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

namespace LibraryManager.View.CustomControls.Buttons
{
    public partial class ItemActionButtonControl : UserControl
    {

        public static readonly DependencyProperty ContentFontSizeProperty = DependencyProperty.Register("ContentFontSize", typeof(int), typeof(ItemActionButtonControl), new PropertyMetadata(23));
        public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register("ButtonWidth", typeof(int), typeof(ItemActionButtonControl), new PropertyMetadata(85));
        public static readonly DependencyProperty ButtonHeightProperty = DependencyProperty.Register("ButtonHeight", typeof(int), typeof(ItemActionButtonControl), new PropertyMetadata(40));
        public static readonly DependencyProperty ButtonBackgroundColorProperty = DependencyProperty.Register("ButtonBackgroundColor", typeof(Brush), typeof(ItemActionButtonControl), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#faffc5"))));
        public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register("ButtonText", typeof(string), typeof(ItemActionButtonControl), new PropertyMetadata("Text"));



        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public Brush ButtonBackgroundColor
        {
            get { return (Brush)GetValue(ButtonBackgroundColorProperty); }
            set { SetValue(ButtonBackgroundColorProperty, value); }
        }

        public int ContentFontSize
        {
            get { return (int)GetValue(ContentFontSizeProperty); }
            set { SetValue(ContentFontSizeProperty, value); }
        }
        public int ButtonWidth
        {
            get { return (int)GetValue(ButtonWidthProperty); }
            set { SetValue(ButtonWidthProperty, value); }
        }
        public int ButtonHeight
        {
            get { return (int)GetValue(ButtonHeightProperty); }
            set { SetValue(ButtonHeightProperty, value); }
        }

        public event RoutedEventHandler ButtonClick;

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick?.Invoke(this, e);
        }


        public ItemActionButtonControl()
        {
            InitializeComponent();
        }
    }
}

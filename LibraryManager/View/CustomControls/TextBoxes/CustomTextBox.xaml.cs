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

namespace LibraryManager.View.CustomControls.TextBoxes
{
    /// <summary>
    /// Logika interakcji dla klasy CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl
    {

        public static readonly DependencyProperty TextBoxTextProperty = DependencyProperty.Register("TextBoxText", typeof(string), typeof(CustomTextBox), new PropertyMetadata("Text"));
        public static readonly DependencyProperty TextBoxFontSizeProperty = DependencyProperty.Register("TextBoxFontSize", typeof(int), typeof(CustomTextBox), new PropertyMetadata(20));
        public static readonly DependencyProperty TextBoxWidthProperty = DependencyProperty.Register("TextBoxWidth", typeof(int), typeof(CustomTextBox), new PropertyMetadata(80));
        public static readonly DependencyProperty TextBoxHeightProperty = DependencyProperty.Register("TextBoxHeight", typeof(int), typeof(CustomTextBox), new PropertyMetadata(50));

        public string TextBoxText
        {
            get { return (string)GetValue(TextBoxTextProperty); }
            set { SetValue(TextBoxTextProperty, value); }
        }

        public int TextBoxFontSize
        {
            get { return (int)GetValue(TextBoxFontSizeProperty); }
            set { SetValue(TextBoxFontSizeProperty, value); }
        }

        public int TextBoxWidth
        {
            get { return (int)GetValue(TextBoxWidthProperty); }
            set { SetValue(TextBoxWidthProperty, value); }
        }

        public int TextBoxHeight
        {
            get { return (int)GetValue(TextBoxHeightProperty); }
            set { SetValue(TextBoxHeightProperty, value); }
        }

        public event TextChangedEventHandler TextChanged;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }

        public CustomTextBox()
        {
            InitializeComponent();
        }
    }
}

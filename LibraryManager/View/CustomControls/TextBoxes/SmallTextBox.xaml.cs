using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy SmallTextBox.xaml
    /// </summary>
    public partial class SmallTextBox : UserControl
    {

        public static readonly DependencyProperty TextBoxTextProperty = DependencyProperty.Register("TextBoxText", typeof(int), typeof(SmallTextBox), new PropertyMetadata(0));
        public static readonly DependencyProperty TextBoxFontSizeProperty =DependencyProperty.Register("TextBoxFontSize", typeof(int), typeof(SmallTextBox), new PropertyMetadata(20));
        public static readonly DependencyProperty TextBoxWidthProperty = DependencyProperty.Register("TextBoxWidth", typeof(int), typeof(SmallTextBox), new PropertyMetadata(80));
        public static readonly DependencyProperty TextBoxHeightProperty = DependencyProperty.Register("TextBoxHeight", typeof(int), typeof(SmallTextBox), new PropertyMetadata(50));

        public int TextBoxText
        {
            get { return (int)GetValue(TextBoxTextProperty); }
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

        public SmallTextBox()
        {
            InitializeComponent();
        }


        private static readonly Regex _numericRegex = new Regex("^[0-9]+$");

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !_numericRegex.IsMatch(e.Text);
        }

        private void NumericTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!_numericRegex.IsMatch(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void NumericTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        public event TextChangedEventHandler TextChanged;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }

    }
}

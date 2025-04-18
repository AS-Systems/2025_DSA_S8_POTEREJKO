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

namespace LibraryManager.View.CustomControls.CheckBox
{
    /// <summary>
    /// Logika interakcji dla klasy CustomCheckbox.xaml
    /// </summary>
    public partial class CustomCheckbox : UserControl
    {
        public int CheckBoxSize
        {
            get { return (int)GetValue(CheckBoxSizeProperty); }
            set { SetValue(CheckBoxSizeProperty, value); }
        }



        public bool Checked
        {
            get { return (bool)GetValue(CheckedProperty); }
            set { SetValue(CheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Checked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckedProperty =
            DependencyProperty.Register("Checked", typeof(bool), typeof(CustomCheckbox), new PropertyMetadata(true));




        public int LabelFontSize
        {
            get { return (int)GetValue(LabelFontSizeProperty); }
            set { SetValue(LabelFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelFontSizeProperty =
            DependencyProperty.Register("LabelFontSize", typeof(int), typeof(CustomCheckbox), new PropertyMetadata(16));



        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(CustomCheckbox), new PropertyMetadata("Text"));



        // Using a DependencyProperty as the backing store for CheckBoxSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckBoxSizeProperty =
            DependencyProperty.Register("CheckBoxSize", typeof(int), typeof(CustomCheckbox), new PropertyMetadata(27));

        public CustomCheckbox()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler CheckedChanged;
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Checked = true;
            CheckedChanged?.Invoke(this, e);
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Checked = false;
            CheckedChanged?.Invoke(this, e);
        }
    }



    


}

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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManager.View.CustomControls.Buttons
{
    /// <summary>
    /// Logika interakcji dla klasy ComparisonOperationButtonControl.xaml
    /// </summary>
    public partial class ComparisonOperationButtonControl : UserControl
    {   
        public static readonly DependencyProperty ContentFontSizeProperty = DependencyProperty.Register("ContentFontSize", typeof(int), typeof(ComparisonOperationButtonControl), new PropertyMetadata(30));
        public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register("ButtonWidth", typeof(int), typeof(ComparisonOperationButtonControl), new PropertyMetadata(40));
        public static readonly DependencyProperty ButtonHeightProperty = DependencyProperty.Register("ButtonHeight", typeof(int), typeof(ComparisonOperationButtonControl), new PropertyMetadata(50));
        public static readonly DependencyProperty SelectedComparisonOperationProperty = DependencyProperty.Register("SelectedComparisonOperation", typeof(ComparisonOperation), typeof(ComparisonOperationButtonControl), new PropertyMetadata(ComparisonOperation.Greater));

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

        public ComparisonOperation SelectedComparisonOperation
        {
            get { return (ComparisonOperation)GetValue(SelectedComparisonOperationProperty); }
            set { SetValue(SelectedComparisonOperationProperty, value); }
        }


        public ComparisonOperationButtonControl()
        {
            InitializeComponent();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {

            if (OperationText.Text.ToString() == ">")
            {
                OperationText.Text = "≥";
                SelectedComparisonOperation = ComparisonOperation.GreaterOrEqual;
            }
            else if (OperationText.Text.ToString() == "≥")
            {
                OperationText.Text = "=";
                SelectedComparisonOperation = ComparisonOperation.Equal;
            }
            else if (OperationText.Text.ToString() == "=")
            {
                OperationText.Text = "<";
                SelectedComparisonOperation = ComparisonOperation.Lower;
            }
            else if (OperationText.Text.ToString() == "<")
            {
                OperationText.Text = "≤";
                SelectedComparisonOperation = ComparisonOperation.LowerOrEqual;
            }                  
            else if (OperationText.Text.ToString() == "≤")
            {
                OperationText.Text = ">";
                SelectedComparisonOperation = ComparisonOperation.Greater;
            }
                   

        }

    }
}

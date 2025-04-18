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
        public static readonly DependencyProperty SelectedComparisonOperationProperty = DependencyProperty.Register(nameof(SelectedComparisonOperation), typeof(ComparisonOperation), typeof(ComparisonOperationButtonControl), new PropertyMetadata(ComparisonOperation.Greater, OnSelectedComparisonOperationChanged));


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
            UpdateOperationText(SelectedComparisonOperation);
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var next = (int)SelectedComparisonOperation + 1;
            if (next > (int)ComparisonOperation.LowerOrEqual)
                next = 0;

            SelectedComparisonOperation = (ComparisonOperation)next;
        }

        private static void OnSelectedComparisonOperationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ComparisonOperationButtonControl control)
            {
                control.UpdateOperationText((ComparisonOperation)e.NewValue);
            }
        }

        private void UpdateOperationText(ComparisonOperation operation)
        {
            OperationText.Text = operation switch
            {
                ComparisonOperation.Greater => ">",
                ComparisonOperation.GreaterOrEqual => "≥",
                ComparisonOperation.Equal => "=",
                ComparisonOperation.Lower => "<",
                ComparisonOperation.LowerOrEqual => "≤",
                _ => "?"
            };

            ButtonTextChanged?.Invoke(this, new TextChangedEventArgs(TextBox.TextChangedEvent, UndoAction.None));
        }

        public event TextChangedEventHandler ButtonTextChanged;

        private void ButtonText_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonTextChanged?.Invoke(this, e);
        }

    }
}

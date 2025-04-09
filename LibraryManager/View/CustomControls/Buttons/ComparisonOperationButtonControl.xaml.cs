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
        public ComparisonOperationButtonControl()
        {
            InitializeComponent();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            // Play fade-out animation
            var fadeOutStoryboard = (Storyboard)this.Resources["FadeOutStoryboard"];
            fadeOutStoryboard.Begin();

            // Wait for animation to complete before changing the text (0.2 seconds)
            fadeOutStoryboard.Completed += (s, args) =>
            {
                // Change the content (the symbol)
                if (button.Content.ToString() == ">")
                    button.Content = ">=";
                else if (button.Content.ToString() == ">=")
                    button.Content = "=";
                else if (button.Content.ToString() == "=")
                    button.Content = "<";
                else if (button.Content.ToString() == "<")
                    button.Content = "<=";
                else if (button.Content.ToString() == "<=")
                    button.Content = ">";

                // Play fade-in animation
                var fadeInStoryboard = (Storyboard)this.Resources["FadeInStoryboard"];
                fadeInStoryboard.Begin();
            };
        }

    }
}

using System;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibraryManager.View.CustomControls.Buttons
{
    /// <summary>
    /// Logika interakcji dla klasy ItemTemplateActionButton.xaml
    /// </summary>
    public partial class ItemTemplateActionButton : UserControl
    {

        public Brush ButtonBackground
        {
            get { return (Brush)GetValue(ButtonBackgroundProperty); }
            set { SetValue(ButtonBackgroundProperty, value); }
        }

        public static readonly DependencyProperty ButtonBackgroundProperty =  DependencyProperty.Register("ButtonBackground", typeof(Brush), typeof(ItemTemplateActionButton), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#faffc5"))));

        public string IconPath
        {
            get { return (string)GetValue(IconPathProperty); }
            set { SetValue(IconPathProperty, value); }
        }

        public static readonly DependencyProperty IconPathProperty = DependencyProperty.Register("IconPath", typeof(string), typeof(ItemTemplateActionButton), new PropertyMetadata(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "image-icon.png")));


        public event RoutedEventHandler ItemClicked
        {
            add { AddHandler(ItemTemplateButtonClickedEvent, value); }
            remove { RemoveHandler(ItemTemplateButtonClickedEvent, value); }
        }
        public static readonly RoutedEvent ItemTemplateButtonClickedEvent = EventManager.RegisterRoutedEvent(nameof(ItemClicked), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ItemTemplateActionButton));


        public ItemTemplateActionButton()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ItemTemplateButtonClickedEvent));
        }
    }
}

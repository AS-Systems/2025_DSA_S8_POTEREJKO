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
    /// Logika interakcji dla klasy Capsule.xaml
    /// </summary>
    public partial class Capsule : UserControl
    {
        public Capsule()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty CapsuleBackgroundProperty = DependencyProperty.Register("CapsuleBackground", typeof(Brush), typeof(Capsule), new PropertyMetadata(Brushes.AliceBlue));
        public static readonly DependencyProperty CapsuleRadiusProperty = DependencyProperty.Register("CapsuleRadius", typeof(int), typeof(Capsule), new PropertyMetadata(65));
        public Brush CapsuleBackground
        {
            get { return (Brush)GetValue(CapsuleBackgroundProperty); }
            set { SetValue(CapsuleBackgroundProperty, value); }
        }

        public int CapsuleRadius
        {
            get { return (int)GetValue(CapsuleRadiusProperty); }
            set { SetValue(CapsuleRadiusProperty, value); }
        }

    }
}

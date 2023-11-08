using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarApp
{
    /// <summary>
    /// Interaction logic for BMW.xaml
    /// </summary>
    public partial class BMW : Page
    {
        public BMW()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрываем Popup
            Popup popup = this.Parent as Popup;
            popup.IsOpen = false;
        }
    }
}

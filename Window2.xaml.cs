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
using System.Windows.Shapes;

namespace CarApp
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Открываем окно Page в виде Popup
            OpenPage();
        }
        private void Porsche_MouseLeftButton(object sender, MouseButtonEventArgs e)
        {
            OpenPage2();
        }
        private void SLS_MouseLeftButtonDown(object sender,MouseButtonEventArgs e)
        {
            OpenPage3();
        }

        private void Audi_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenPage4();
        }
            private void OpenPage2()
        {
            Window window = new Window();
            window.Title = "Porsche 959";

            Image image = new Image();
            string PathImage = "C:\\Users\\maxim\\Downloads\\CarApp111\\CarApp\\959.jpg";
            image.Source = new BitmapImage(new Uri(PathImage, UriKind.Relative)); 

            window.Content = image;
            window.ShowDialog();
        }
        private void OpenPage()
        {
            Window window = new Window();
            window.Title = "BMW M4";

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("C:\\Users\\maxim\\Downloads\\CarApp111\\CarApp\\Images\\bmw-m4-gts-ol065.jpg")); 

            window.Content = image;
            window.ShowDialog();
        }
        private void OpenPage3()
        {
            Window window = new Window();
            window.Title = "Mersedes SLS AMG";

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("C:\\Users\\maxim\\Downloads\\CarApp111\\CarApp\\Images\\1200px-Mercedes-Benz_SLS_AMG_(C_197)_–_Frontansicht_geöffnet,_10._August_2011,_Düsseldorf.jpg")); 

            window.Content = image;
            window.ShowDialog();
        }
        private void OpenPage4()
        {
            Window window = new Window();
            window.Title = "AUDI 100";

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("C:\\Users\\maxim\\Downloads\\CarApp111\\CarApp\\Images\\audi_100_552488.jpg")); 

            window.Content = image;
            window.ShowDialog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Открытие нового окна
            AllCar newWindow = new AllCar();
            newWindow.Show();
            this.Close();
        }
    }
}

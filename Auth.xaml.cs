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
using System.Windows.Shapes;

namespace CarApp
{
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;


            // Проверка на пустое поле
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            // Проверка введенных данных
            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Авторизация успешна!");
                Login.IsEnabled = true;
                var secondWindow = new Window2();

                // Открытие второго окна
                secondWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Авторизация не успешна!");
                Login.IsEnabled = true;
            }
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            // Создание нового экземпляра второго окна
        }
        [STAThread]
        public static void Main()
        {
            // Создание и запуск главного окна приложения
            Application app = new Application();
            app.Run(new Auth());
        }
    }
}
using System.Collections.Generic;
using System.Windows;

namespace CarApp
{
    public partial class AllCar : Window
    {
        private List<Car> cars;

        public AllCar()
        {
            InitializeComponent();

            cars = new List<Car>
            {
                new Car { Model = "Porsche", Brand = "928s", Price = 10000 },
                new Car { Model = "BMW", Brand = "2002 Turbo", Price = 20000 },
                new Car { Model = "Mclaren", Brand = "P1", Price = 30000 }
            };

            AllCars.ItemsSource = cars;
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            var addCarWindow = new AddCarWindow();
            addCarWindow.ShowDialog();

            if (addCarWindow.DialogResult.HasValue && addCarWindow.DialogResult.Value)
            {
                var newCar = new Car
                {
                    Model = addCarWindow.Model,
                    Brand = addCarWindow.Brand,
                    Price = addCarWindow.Price
                };

                cars.Add(newCar);
                AllCars.Items.Refresh();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var secondWindow = new Window2();
            secondWindow.Show();
            this.Close();
        }
    }

    public class Car
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
    }
}
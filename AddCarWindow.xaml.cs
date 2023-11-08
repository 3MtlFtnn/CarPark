using System.Windows;

namespace CarApp
{
    public partial class AddCarWindow : Window
    {
        public string Model { get; private set; }
        public string Brand { get; private set; }
        public int Price { get; private set; }

        public AddCarWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Model = ModelTextBox.Text;
            Brand = BrandTextBox.Text;

            if (int.TryParse(PriceTextBox.Text, out int price))
            {
                Price = price;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Введите корректную цену!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
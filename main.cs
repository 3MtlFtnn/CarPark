using System;
using System.Text.RegularExpressions;
namespace CarPark
{
    public class Car
    {
        public string Brand { get; set; } // марка автомобиля
        public string Model { get; set; } // модель автомобиля
        public int Year { get; set; } // год выпуска автомобиля
        public double EngineCapacity { get; set; } // объем двигателя автомобиля

        // конструктор класса
        public Car(string brand, string model, int year, double engineCapacity)
        {
            if (!Regex.IsMatch(year.ToString(), @"^19\d{2}|20[01]\d|202[0-9]$"))
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Year must be from 1900 to latest year");
            }
            if (year < 1900 || year > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Year must be from 1900 to latest year");
            }
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentException("Mark cant be empty", nameof(brand));
            }
            if (engineCapacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(engineCapacity), "Engine compasity must be positive");
            }
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Model cant be empty", nameof(model));
            }
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.EngineCapacity = engineCapacity;
        }
        public override string ToString()
        {
            if (EngineCapacity > 0)
            {
                return $"Mark: {Brand}, Model: {Model}, Year: {Year}, Engine: {EngineCapacity} l";
            }
            else
            {
                return "";
            }
        }
    }
    class Electric : Car
    {
        public double BatteryCapacity { get; set; }
        public Electric(string brand, string model, int year, double engineCapacity, double batteryCapacity)
            : base(brand, model, year, engineCapacity)
        {
            if (EngineCapacity == 0)
            {
                BatteryCapacity = batteryCapacity;
            }
        }
        public override string ToString()
        {
            if (EngineCapacity == 0)
            {
                return $"Mark: {Brand}, Model: {Model},  Year: {Year}, Battery: {BatteryCapacity} W";
            }
            else
            {
                return base.ToString();
            }
        }

    }
    class Catalog
    {
        // массив автомобилей
        private Car[] cars;

        // конструктор класса
        public Catalog()
        {
            cars = new Car[0];
        }

        // метод добавления автомобиля в каталог
        public void AddCar(Car car)
        {
            Array.Resize(ref cars, cars.Length + 1);
            cars[cars.Length - 1] = car;
        }

        public void AddCar(string brand, string model, int year, double engineCapacity)
        {
            Car car = new Car(brand, model, year, engineCapacity);
            AddCar(car);
        }

        public void AddCar(string brand, string model, int year, double engineCapacity, double batteryCapacity)
        {
            Electric car = new Electric(brand, model, year, engineCapacity, batteryCapacity);
            AddCar(car);
        }

        // метод удаления автомобиля из каталога по индексу
        public void RemoveCar(int index)
        {
            if (index >= 0 && index < cars.Length)
            {
                for (int i = index; i < cars.Length - 1; i++)
                {
                    cars[i] = cars[i + 1];
                }
                Array.Resize(ref cars, cars.Length - 1);
            }
        }

        // метод изменения данных об автомобиле по индексу
        public void EditCar(int index, Car car)
        {
            if (index >= 0 && index < cars.Length)
            {
                cars[index] = car;
            }
        }

        // метод вывода информации обо всех автомобилях в каталоге
        public int PrintCatalog()
        {
            if (cars.Length == 0)
            {
                Console.WriteLine("Catalog empty!");
            }
            else
            {
                Console.WriteLine("Cars in catalog:");
                for (int i = 0; i < cars.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {cars[i]}");
                }
            }
            return cars.Length;
        }
    }
    struct MenuItem
    {
        public string Title;
        public Action Handler;
    }
    class CarPark
    {

        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            catalog.AddCar(new Car("BMW", "X5", 2021, 3.0));
            catalog.AddCar(new Car("Audi", "Q7", 2019, 2.0));
            catalog.AddCar(new Car("Mercedes-Benz", "GLE", 2020, 3.5));

            // массив пунктов меню
            MenuItem[] menuItems = new MenuItem[]
            {
                new MenuItem { Title = "Add car", Handler = () => {
                    Console.Write("Mark: ");
                    string brand = Console.ReadLine();
                    Console.Write("Model: ");
                    string model = Console.ReadLine();
                    Console.Write("Year: ");
                    int year = Int32.Parse(Console.ReadLine());
                    Console.Write("Engine compasity: ");
                    double engineCapacity = Double.Parse(Console.ReadLine());
                    if (engineCapacity == 0)
                    {
                        Console.Write("Battery compasity: ");
                        double batteryCapacity = Double.Parse(Console.ReadLine());
                        catalog.AddCar(new Electric(brand, model, year, engineCapacity, batteryCapacity));
                    }
                    else
                    {
                        catalog.AddCar(new Car(brand, model, year, engineCapacity));
                    }
                    Console.WriteLine("Car added secsesfull!");
                }},
                new MenuItem { Title = "Delete", Handler = () => {
                    if (catalog.PrintCatalog() == 0)
                    {
                        Console.WriteLine("Empty catalog!");
                    }
                    else
                    {
                        Console.Write("Enter number car: ");
                        int index = Int32.Parse(Console.ReadLine()) - 1;
                        catalog.RemoveCar(index);
                        Console.WriteLine("Car deleted!");
                    }
                }},
                new MenuItem { Title = "Edit information car", Handler = () => {
                    if (catalog.PrintCatalog() == 0)
                    {
                        Console.WriteLine("Empty catalog!");
                    }
                    else
                    {
                        Console.Write("Enter number of car: ");
                        int index = Int32.Parse(Console.ReadLine()) - 1;
                        Console.Write("Mark: ");
                        string brand = Console.ReadLine();
                        Console.Write("Model: ");
                        string model = Console.ReadLine();
                        Console.Write("Year: ");
                        int year = Int32.Parse(Console.ReadLine());
                        Console.Write("Engine compasity: ");
                        double engineCapacity = Double.Parse(Console.ReadLine());
                        catalog.EditCar(index, new Car(brand, model, year, engineCapacity));
                        Console.WriteLine("Information of cars edited!");
                    }
                }},
                new MenuItem { Title = "Run Test", Handler = () =>
                {
                    try{
                        Console.WriteLine("Mark: ");
                        string brand = Console.ReadLine();
                        Console.WriteLine("Model: ");
                        string model = Console.ReadLine();
                        Console.WriteLine("Year: ");
                        int year = Int32.Parse(Console.ReadLine());
                        Console.Write("Engine capacity: ");
                        double engineCapacity = Double.Parse(Console.ReadLine());
                        if(engineCapacity==0)
                        {
                            Console.WriteLine("Batterey Capacity: ");
                            double batteryCapacity = Double.Parse(Console.ReadLine());
                            catalog.AddCar(new Electric(brand, model, year, engineCapacity, batteryCapacity));
                        }
                        else
                        {
                            catalog.AddCar(new Car(brand, model, year, engineCapacity));=
                }},
                new MenuItem { Title = "Exit", Handler = () => Environment.Exit(0) }
            };

            // цикл вывода меню и обработки выбранных пунктов
            while (true)
            {
                Console.WriteLine("Menu:");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {menuItems[i].Title}");
                }
                Console.Write("Enter number: ");
                int choice = Int32.Parse(Console.ReadLine()) - 1;
                if (choice >= 0 && choice < menuItems.Length)
                {
                    menuItems[choice].Handler();
                }
                else
                {
                    Console.WriteLine("Please try again!");
                }
                Console.WriteLine();
            }
        }
    }
}
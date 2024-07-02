using System;

namespace cars
{
    public class Car
    {
        public int Make { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int Model { get; set; }
        public int Pallet_No { get; set; }
        public string Color { get; set; }

        public Car(int make, int year, string type, double price, int model, int pallet_No, string color)
        {
            this.Make = make;
            this.Year = year;
            this.Type = type;
            this.Price = price;
            this.Model = model;
            this.Pallet_No = pallet_No;
            this.Color = color;
        }

        public void Start()
        {
            Console.WriteLine($"The car {Model} has just started.");
        }

        public void Stop()
        {
            Console.WriteLine($"The car {Model} has just stopped.");
        }

        public string CarInfo()
        {
            Console.WriteLine("this methods returns cars info ... ");
            return $"The car info is: make: {Make}, year: {Year}, type: {Type}, price: {Price}, model: {Model}, pallet No.: {Pallet_No}, color: {Color}";
        }
    }

    public class BMW : Car
    {
        public BMW(int make, int year, string type, double price, int model, int pallet_No, string color)
            : base(make, year, type, price, model, pallet_No, color)
        {
        }

 
    }

    class Program
    {
        static void Main()
        {
            // Parent class object 

            Car car = new Car(1, 1990, "Benz", 25000, 3, 345546, "Red");

            Console.WriteLine(car.Year);
            Console.WriteLine(car.Make);
            car.Start();
            car.Stop();
            car.CarInfo();



            // Derived class object

            BMW bmwCar = new BMW(2, 2006, "BMW", 30000, 5, 657879, "Red");

            Console.WriteLine(bmwCar.Year);
            Console.WriteLine(bmwCar.Make);
            
            bmwCar.Stop();
            bmwCar.Start();
            bmwCar.CarInfo();
           
        }
    }
}

using Microsoft.VisualBasic;
using System;
using System.Globalization;


namespace cars
{



    public class Car
    {
        protected int year;
        protected string type;
        protected string model;
        protected string pallet_no;
        protected string color;


        public int Year
        {

            set
            {
                year = value;
            }
            get { return year; }
        }



        public Car(int year, string type, string model, string pallet_no, string color)
        {
            this.year = year;
            this.type = type;
            this.model = model;
            this.pallet_no = pallet_no;
            this.color = color;

        }

       


        protected void Start()
        {
            Console.WriteLine("the car has just started");
        }


        protected void Stop()
        {
            Console.WriteLine("the car has just stopped");
        }
        

        protected string Car_info()
        {


            return $"the car info is : year: {year} , type : {type} , model : {model} , pallet N.o {pallet_no} , color : {color}"; 

        }
        

    }

    public class BMW : Car
    {
        public BMW(int year, string model, string pallet_no, string color) : base(1990, "BMW", model, pallet_no, color)
        {
            this.year = year;
            this.model = model;
            this.pallet_no = pallet_no;
            this.color = color;

        }
        public string GetCarInfo()
        {
            return Car_info();
        }
        public void GetStop()
        {
            Stop();

        }
        public void GetStart()
        {
            Start();

        }
    }
    class Program


    {
        static void Main()
        {
            Car car = new Car(1990, "benz", "t", "345546", "red");
            
            Console.WriteLine(car.Year);

            BMW bmw_car = new BMW(2006, "bmw", "657879", "red");

            Console.WriteLine(bmw_car.Year);

            Console.WriteLine(bmw_car.GetCarInfo()); 
            bmw_car.GetStop();
            bmw_car.GetStart();


        }
    }

}
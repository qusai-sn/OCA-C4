using System;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Task one : \n");

            Console.Write("Enter the first number: ");
            string input1 = Console.ReadLine();
            int num1 = int.Parse(input1);

            Console.Write("Enter the second number: ");
            string input2 = Console.ReadLine();
            int num2 = int.Parse(input2);

            if (num1 > num2)
            {
                Console.WriteLine(num1);
            }
            else if (num1 < num2)
            {
                Console.WriteLine(num2);
            }
            else
            {
                Console.WriteLine($"{num1} is equal to {num2}");
            }


            Console.Write("Task 2 : \n");

            Console.Write("enter a number");

            string input3 = Console.ReadLine();
            int num3 = int.Parse(input3);

            if (num3 > 0)
            {
                Console.WriteLine("+");
            }
            else
            {
                Console.WriteLine("-");
            }

            Console.Write("Task 3 : \n");
            int x = 0;
            int y = -1;
            int z = 4;

            int smallest, middle, largest;

            if (x <= y && x <= z)
            {
                smallest = x;
                if (y <= z)
                {
                    middle = y;
                    largest = z;
                }
                else
                {
                    middle = z;
                    largest = y;
                }
            }
            else if (y <= x && y <= z)
            {
                smallest = y;
                if (x <= z)
                {
                    middle = x;
                    largest = z;
                }
                else
                {
                    middle = z;
                    largest = x;
                }
            }
            else
            {
                smallest = z;
                if (x <= y)
                {
                    middle = x;
                    largest = y;
                }
                else
                {
                    middle = y;
                    largest = x;
                }
            }


            Console.WriteLine($"The numbers in  order are: {smallest}, {middle}, {largest}");

            Console.Write("Task 4 : \n");

            int a = -5;
            int b = -2;
            int c = -6;
            int d = 0;
            int e = -1;

            int max = a;

            if (b > max)
            {
                max = b;
            }

            if (c > max)
            {
                max = c;
            }

            if (d > max)
            {
                max = d;
            }

            if (e > max)
            {
                max = e;
            }

            Console.WriteLine($"Max  is: {max}");



            Console.Write("Task 5 : \n");

            Console.Write("kilometers per hour: ");
            double k = double.Parse(Console.ReadLine());


            double m = k * 0.621371;


            Console.WriteLine($"{k} kilometers per hour is equal to {m:F6} miles per hour");



            Console.Write("Task 6 : \n");

            Console.Write("input hours: ");
            int hours = int.Parse(Console.ReadLine());

            Console.Write("input minutes: ");
            int minutes = int.Parse(Console.ReadLine());

            int total = hours * 60 + minutes;

            Console.WriteLine($"Total: {total} minutes.");


            Console.Write("Task 7 : \n");

            Console.Write(" minutes: ");
            int total_m = int.Parse(Console.ReadLine());

            int hours_2 = total_m / 60;
            int remains = total_m % 60;


            Console.WriteLine($"{hours_2} Hours, {remains} Minutes ");

            Console.Write("Task 8 : \n");

            string[] sentences = new string[]
            {
                "uuuuu",
                "ooooo",
                "eeeeeeeeee",
                "ssssssssss",
                "TTTTTT"
            };

 
            foreach (string sentence in sentences)
            {
                Console.WriteLine($"Sentence: {sentence}");
                Console.WriteLine($"Length: {sentence.Length}");
                Console.WriteLine(); 
            }
        }

    }
}

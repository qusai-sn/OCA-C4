using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[10];

        Console.WriteLine("Enter 10 numbers:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Number-{i + 1}: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        var (sum, average) = SumAndAverage(numbers);


        Console.WriteLine($"The sum of 10 numbers is: {sum}");
        Console.WriteLine($"The Average is: {average:F6}");

        Console.Write("Input number of terms: ");
        int terms = Convert.ToInt32(Console.ReadLine());

        DisplayCubes(terms);

        int[] years = { 1763, 1972, 1925, 1916, 1984, 1124, 1950, 2020 };

        var filteredYears = GetYears(years);

        Console.WriteLine("Years greater than 1950:");
        foreach (int year in filteredYears)
        {
            Console.WriteLine(year);
        }

        int ageInYears = 25;
        int ageInDays = AgeInDays(ageInYears);

        Console.WriteLine($"Age in days: {ageInDays}");


        Console.WriteLine($"The object person :");

        Person person = new Person();
        person.Age = 20;
        person.Phone = "0778976885";

        Console.WriteLine(person.Age);
        Console.WriteLine(person.Phone);



    }

    //#1:

    static (int, double) SumAndAverage(int[] numbers)
    {
        int sum = 0;

        foreach (int num in numbers)
        {
            sum += num;
        }

        double average = (double)sum / numbers.Length;

        return (sum, average);
    }


    //#2:

    static void DisplayCubes(int terms)
    {
        for (int i = 1; i <= terms; i++)
        {
            int cube = i * i * i;
            Console.WriteLine($"Number is : {i} and cube of the {i} is : {cube}");
        }

    }

    //#3:

    static int[] GetYears(int[] years)
    {
        var filteredYears = years.Where(year => year > 1950).ToArray();

        return filteredYears;
    }

    //#4: 

    static int AgeInDays(int ageInYears)
    {
        int ageInDays = ageInYears * 365;
        return ageInDays;
    }

    //#5:

    class Person
    {
        private int age = 18;
        private string gender = "male";
        private string name = "mohammad";
        private string email = "mohammad@gmail.com";
        private string id = 18329304;
        private string phone = "077";



        // Properties
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 18 && value <= 60)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Age must be between 18 and 60.");
                }
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                if (value.StartsWith("077") || value.StartsWith("078") || value.StartsWith("079"))
                {
                    phone = value;
                }
                else
                {
                    throw new ArgumentException("Phone must start with '077', '078', or '079'.");
                }
            }
        }

    }
}



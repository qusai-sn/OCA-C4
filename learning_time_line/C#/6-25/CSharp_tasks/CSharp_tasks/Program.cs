

using System;

class Program
{
    static void Main()
    {

        //1 : 
        double pie = 3.14;
        string hello = "Hello, world!";
        char Char = 'A';
        bool boolean = true;
        int num = 42;
        const int Const1 = 100;

         
        Console.WriteLine($"Double: {pie}");
        Console.WriteLine($"String: {hello}");
        Console.WriteLine($"Char: {Char}");
        Console.WriteLine($"Bool: {boolean}");
        Console.WriteLine($"Int: {num}");
        Console.WriteLine($"Const: {Const1}");

        Console.ReadLine();


        //2 :
        string[] cars = { "Toyota", "Honda", "Ford", "toyota-2" };
        Console.WriteLine("\n THe Cars is :");
        foreach (string car in cars)
        {
            Console.WriteLine(car);
        }
        Console.WriteLine($"Array length is : {cars.Length}");


        //3 : 

        Console.Write("\n  firstname: ");
        string firstName = Console.ReadLine();
        Console.Write(" lastname: ");
        string lastName = Console.ReadLine();
        Console.Write("year of birth: ");
        int yearOfBirth = int.Parse(Console.ReadLine());

        Console.WriteLine($"{firstName} {lastName} {yearOfBirth}");



        // 4 : 

        int[] elements = new int[10];
        Console.WriteLine("\n write 10 things :");

        for (int i = 0; i < 10; i++){

            Console.Write($"element - {i} : ");
            elements[i] = int.Parse(Console.ReadLine());

        }

        Console.Write("element are : ");
        foreach (int element in elements){

            Console.Write($"{element}");
        }

        Console.WriteLine();



        // 5:

        int sum = 0;
        foreach (int element in elements){

            sum += element;

        }
        Console.WriteLine($"Sum of all elements is: {sum}");
        Console.ReadLine();





        // 6 :

         Console.WriteLine("write array separated by spaces:");
         string input = Console.ReadLine();

         string[] numbers = input.Split(' ');

         int[] array = new int[numbers.Length];

         for (int i=0; i<numbers.Length; i++){

            array[i]= int.Parse(numbers[i]);

        }

         int sum2=0;
        foreach (int num2 in array)
        {
            sum += num2;
        }
        Console.WriteLine($"Sum of  array is : {sum}");
        Console.ReadLine();







    }
}



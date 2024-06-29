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

            int[] larger = {num1 , num2 };
            Array.Sort(larger);
            Console.Write($"the larger number is {larger[1]}");


            Console.Write("Task 2 : \n");

            Console.Write("enter a number");

            string input3 = Console.ReadLine();
            string[] signs = {"-","0","+"};
            int num3 = int.Parse(input3);
            int sign = Math.Sign(num3);
            Console.WriteLine(signs[sign+1]);



            Console.Write("Task 3 : \n");
            
            int[] numbers = { 5, 2, 9 };
            Array.Sort(numbers);


            Console.WriteLine($"The numbers in  order are: min is {numbers[0]} , mid is {numbers[1]} , max is {numbers[2]}");

            Console.Write("Task 4 : \n");

            int[] numbers2 = { 5, 2, 9 };
            Array.Sort(numbers2);

            Console.WriteLine($"Max  is: {numbers2[numbers2.Length-1]}");



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
                "oooo3534o",
                "eeeee435eee234ee",
                "sssss5ss423sss",
                "TTTT534543TT"
            };

            int minLength = sentences.Min(s => s.Length);

            Console.WriteLine(sentences[0].Substring(0, minLength));
            Console.WriteLine(sentences[1].Substring(0, minLength));
            Console.WriteLine(sentences[2].Substring(0, minLength));
            Console.WriteLine(sentences[3].Substring(0, minLength));
            Console.WriteLine(sentences[4].Substring(0, minLength));

        }

    }
}

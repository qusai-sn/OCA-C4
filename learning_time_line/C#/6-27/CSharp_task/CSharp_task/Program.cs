using System;
using System.Linq;
using System.Reflection;

class Program
{
    static void Main()
    {
        //#1:

        //string[] ARR = [1, 7  9  45,]
        string[] arr1 = { "1", "7", "9", "45" };

        //int arr2 = ["Str" "alex","moh"
        string[] arr2 = { "Str", "alex", "moh" };

        //string arr3= 'the','fox' 'over' lazy, 'dog',  ]
        string[] arr3 = { "the", "fox", "over", "lazy", "dog" };


        //#2:

        //String[ ]  fruits = ["Tomato", "Banana", "Watermelon"]
        //What the index of "Banana","Tomato" ?  >>  1 , 0 .


        //#3:

        string[] favoriteFoods = { "Mansaf", "Falafel", "Ma6loba", " not Burgers" };
        string[] favoriteSports = { "Football", "Basketball", "Boxing" };
        string[] favoriteMovies = { "AOT", "The Dark Knight", "Onpe Piece 10", "Pulp Fiction" };

        Console.WriteLine("Favorite Foods:");
        foreach (var i in favoriteFoods)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("\nFavorite Sports:");
        foreach (var i in favoriteSports)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("\nFavorite Movies:");
        foreach (var i in favoriteMovies)
        {
            Console.WriteLine(i);
        }


        //#4:

        Console.WriteLine("write three numbers:");
        string input = Console.ReadLine();

        int sum = input.Split(',').Select(int.Parse).Sum();

        Console.WriteLine($"The sum is : {sum}");

        //#5: 

        int odds = 0;
        string oddText = "the odd numbers are  : ";
        for (int i = 1; i < 100; i += 2)
        {
            oddText += i.ToString() + ", ";
            odds += i;
        }

        Console.WriteLine($"the sum of add numbers is {odds}");
        Console.WriteLine(oddText);

        //#6:

        int raws = 7;
        for (int i = 0; i < raws; i++)
        {
            for(int s = 0; s < raws-i; s++)
            {
                Console.Write(" ");
            }
            for(int j = 0; j < i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }


        //#7:

        int raws2 = 5;
        int counter = 0;
        for (int i = 0; i < raws2; i++)
        {
            for (int s = 0; s < raws2 - i; s++)
            {
                Console.Write(" ");
            }
            for (int j = 0; j < i; j++)
            {
                Console.Write($"{counter} ");
                counter++;
            }
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            var result = book.GetStatistics();

            var input = Console.ReadLine();
            var grade = double.Parse(input);

            Console.WriteLine($"The lowest grade is {result.Low}");
            Console.WriteLine($"The highest grade is {result.High}");
            Console.WriteLine($"The avarage grade is {result.Avarage:N1}");
            Console.WriteLine($"The letter grade is {result.Letter}");
        }
    }
}

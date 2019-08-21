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

            Console.WriteLine($"The lowest grade is {result.Low:N1}");
            Console.WriteLine($"The highest grade is {result.High:N1}");
            Console.WriteLine($"The avarage grade is {result.Avarage:N1}");
        }
    }
}

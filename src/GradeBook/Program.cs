using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book? book = new InMemoryBook("Scott's Grade InMemoryBook");
            book.GradeAdded += OnGradeAdded;

            book.AddGrade(89.1);
            book.AddGrade(90.5);
            var result = book.GetStatistics();

            EnterGrades(book);

            book.Name = "";

            Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"For the inMemoryBook named {book.Name}");
            Console.WriteLine($"The lowest grade is {result.Low}");
            Console.WriteLine($"The highest grade is {result.High}");
            Console.WriteLine($"The avarage grade is {result.Avarage:N1}");
            Console.WriteLine($"The letter grade is {result.Letter}");
        }

        private static void EnterGrades(IBook inMemoryBook)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    inMemoryBook.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
    }
}

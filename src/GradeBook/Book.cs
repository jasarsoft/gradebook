using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            this.grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }

        internal void ShowStatistics()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach(var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Max(number, lowGrade);
                result += number;
            }
            result /= grades.Count;
            Console.WriteLine($"The lowest grade is {lowGrade:N1}");
            Console.WriteLine($"The highest grade is {highGrade:N1}");
            Console.WriteLine($"The avarage grade is {result:N1}");
        }

        private List<double> grades;
        private string name;
    }
}
using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            this.grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid value");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Avarage = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            foreach(var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Max(grade, result.Low);
                result.Avarage += grade;
            }
            result.Avarage /= grades.Count;
            return result;
        }

        public List<double> grades;
        public string Name;
    }
}
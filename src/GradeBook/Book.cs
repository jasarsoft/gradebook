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

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
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
            for(var index = 0; index < grades.Count; index++)
            {
                if (grades[index] == 42.1)
                {
                    break;
                }

                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Max(grades[index], result.Low);
                result.Avarage += grades[index];
            }
            result.Avarage /= grades.Count;
            return result;
        }

        public List<double> grades;
        public string Name;
    }
}
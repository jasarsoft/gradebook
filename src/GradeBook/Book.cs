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

        public void AddGrade(char letter)
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
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Avarage = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            for (var index = 0; index < grades.Count; index++)
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

            switch (result.Avarage)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        public List<double> grades;

        public string Name { get; set; }

        public const string CATEGORY = "Science";
    }
}
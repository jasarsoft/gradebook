using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class NamedObject: Object
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    /// <summary>
    /// Reporesent a Book interface
    /// </summary>
    public interface IBook
    {
        void AddGrade(double grade);
        
        Statistics GetStatistics();

        string Name { get; }

        event GradeAddedDelegate GradeAdded;
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        public override event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name): base(name)
        {
            
        }

        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();

        public abstract event GradeAddedDelegate GradeAdded;
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name): base(name)
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

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
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

        public const string CATEGORY = "Science";
    }
}
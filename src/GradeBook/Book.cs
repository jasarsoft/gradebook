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

        private List<double> grades;
        private string name;
    }
}
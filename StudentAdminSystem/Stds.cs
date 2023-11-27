using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdminSystem
{
    class Stds
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string StdProgram { get; set; }
        public Dictionary<string, int> Grades;

        public Stds(string name, int age, int id, string program )
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.StdProgram = program;
            this.Grades = new Dictionary<string, int>();
        }

        public void addGrade(string subject, int grade)
        {
            this.Grades[subject] = grade;   

        }

        public void showGrades()
        {   
            Console.WriteLine();
            Console.WriteLine("-----Grades-----");
            foreach (var grade in Grades)
            {
                Console.WriteLine($"Subject {grade.Key} : {grade.Value}");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine("----------");

            Console.WriteLine($"{Name}");
            Console.WriteLine($"Age : {Age}");
            Console.WriteLine($"Main program : {StdProgram}");
        }


    }

}
using System;
using System.Linq;
using System.Collections.Generic;

namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsInfo = new List<Student>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] info = input.Split().ToArray();

                string firstName = info[0];
                string lastName = info[1];
                int age = int.Parse(info[2]);
                string town = info[3];

                if (CheckStudents(studentsInfo, firstName, lastName))
                {
                    studentsInfo = OverwriteInfo(studentsInfo, firstName, lastName, age, town);
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = town,
                    };

                    studentsInfo.Add(student);
                }

                input = Console.ReadLine();
            }

            string city = Console.ReadLine();

            foreach (Student student in studentsInfo)
            {
                if (city == student.City)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        static bool CheckStudents(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }

        static List<Student> OverwriteInfo(List<Student> students, string firstName, string lastName, int age, string city)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    student.Age = age;
                    student.City = city;
                }
            }

            return students;
        }
    }

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
    }
}

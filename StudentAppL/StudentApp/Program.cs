using Microsoft.EntityFrameworkCore;
using StudentApp.Entities;
using static System.Console;

namespace StudentApp;

public class Program
{
    static void Main(string[] args)
    {
        using (var context = new SchoolContext())
        {
            var studentsWithGrades = context.Students.ToList();

            foreach (var student in studentsWithGrades)
            {
                Console.WriteLine($"Student: {student.FirstName}");
                foreach (var grade in student.Grades)
                {
                    Console.WriteLine($"Subject: {grade.Subject.SubjectName}, Grade: {grade.GradeValue}");
                }
            }
        }
    }
}
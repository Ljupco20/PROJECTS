using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Entities;

public class Student
{
    public int StudentID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public ICollection<Grade>? Grades { get; set; }
}

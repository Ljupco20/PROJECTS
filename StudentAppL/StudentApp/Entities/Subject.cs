using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Entities;

public class Subject
{
    public int SubjectID { get; set; }
    public string SubjectName { get; set; }

    public ICollection<Grade>? Grades { get; set; }
}

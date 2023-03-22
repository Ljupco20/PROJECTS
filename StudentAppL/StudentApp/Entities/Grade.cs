using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Entities
{
    public class Grade
    {
        public int GradeID { get; set; }
        public int GradeValue { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}

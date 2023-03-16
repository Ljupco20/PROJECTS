using SchoolApp4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp4.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> Students { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<Grade> Grades { get; }

        void Complete();
    }
}

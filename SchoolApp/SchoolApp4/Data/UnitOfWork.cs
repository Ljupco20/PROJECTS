using SchoolApp4.Interfaces;
using SchoolApp4.Models;
using SchoolApp4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp4.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly SchoolContext _context;

    public UnitOfWork(SchoolContext context)
    {
        this._context = context;

        Students = new Repository<Student>(_context);
        Subjects = new Repository<Subject>(_context);
        Grades = new Repository<Grade>(_context);
    }



    public IRepository<Student> Students { get; private set; }
    public IRepository<Subject> Subjects { get; private set; }
    public IRepository<Grade> Grades { get; private set; }

    public void Complete()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }


}
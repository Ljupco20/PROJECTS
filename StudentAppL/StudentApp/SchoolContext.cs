using Microsoft.EntityFrameworkCore;
using StudentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace StudentApp;

public class SchoolContext :DbContext
{
    public DbSet<Student>? Students { get; set; }
    public DbSet<Subject>? Subjects { get; set; }
    public DbSet<Grade>? Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Academy.db");
        WriteLine($"Using {path} database file.");
        optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog = Academy; Integrated Security = true; MultipleActiveResultSets = true; ");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        
        Student rashford = new()
        {
            StudentID = 1,
            FirstName = "Marcus",
            LastName = "Rashford"
        };
        Student sancho = new()
        {
            StudentID = 2,
            FirstName = "Jadon",
            LastName = "Sancho"
        };
        Student wilson = new()
        {
            StudentID = 3,
            FirstName = "Calum",
            LastName = "Wilson"
        };

        Subject csharp = new()
        {
            SubjectID = 1,
            SubjectName = "C#",
        };
        Subject javascript = new()
        {
            SubjectID = 2,
            SubjectName = "JavaScript",
        };
        Subject sql = new()
        {
            SubjectID = 3,
            SubjectName = "SQL",
        };

        Grade a = new()
        {
            GradeID = 1,
            GradeValue = 1,
        };
        Grade b = new()
        {
            GradeID = 2,
            GradeValue = 2,
        };
        Grade c = new()
        {
            GradeID = 3,
            GradeValue = 3,
        };

        modelBuilder.Entity<Student>()
      .HasData(rashford, sancho, wilson);

        modelBuilder.Entity<Subject>()
          .HasData(csharp, javascript, sql);

        modelBuilder.Entity<Grade>()
          .HasData(a, b, c);

        modelBuilder.Entity<Grade>()
             .HasKey(g => new { g.StudentId, g.SubjectId });

        modelBuilder.Entity<Student>()
              .HasMany(s => s.Grades)
              .WithOne(g => g.Student)
              .HasForeignKey(g => g.StudentId);

        modelBuilder.Entity<Subject>()
            .HasMany(s => s.Grades)
            .WithOne(g => g.Subject)
            .HasForeignKey(g => g.SubjectId);

        modelBuilder.Entity<Grade>()
            .HasKey(g => new { g.StudentId, g.SubjectId });
    }
}
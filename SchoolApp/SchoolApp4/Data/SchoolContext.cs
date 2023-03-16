using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolApp4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace SchoolApp4.Data;

public class SchoolContext : DbContext
{
    public SchoolContext() : base(){}
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
   
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Grade> Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "SchoolApp5.db");
        WriteLine($"Using {path} database file.");
        optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=SchoolApp5; Integrated Security = true; MultipleActiveResultSets = true; TrustServerCertificate=True", builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null));
        base.OnConfiguring(optionsBuilder);
    }
   
}

using Microsoft.EntityFrameworkCore;
using SchoolApp4.Data;
using SchoolApp4.Models;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=SchoolApp6; Integrated Security = true; MultipleActiveResultSets = true; TrustServerCertificate=True");

using (var unitOfWork = new UnitOfWork(context: new SchoolContext(optionsBuilder.Options)))
{

    Student studentLeao = new Student { Name = "Rafael Leao" };
    Student studentWilson = new Student { Name = "Calum Wilson" };
    unitOfWork.Students.Add(studentLeao);
    unitOfWork.Students.Add(studentWilson);


    Subject cSharp = new Subject { Name = "CSharp" };
    Subject javaScript = new Subject { Name = "JavaScript" };
    Subject sql = new Subject { Name = "SQL" };
    unitOfWork.Subjects.Add(cSharp);
    unitOfWork.Subjects.Add(javaScript);
    unitOfWork.Subjects.Add(sql);

    Grade gradeLeaoCS = new Grade { Student = studentLeao, Subject = cSharp, Value = 99 };
    Grade gradeLeaoJS = new Grade { Student = studentLeao, Subject = javaScript, Value = 99 };
    Grade gradeLeaoSQL = new Grade { Student = studentLeao, Subject = sql, Value = 99 };

    unitOfWork.Grades.Add(gradeLeaoCS);
    unitOfWork.Grades.Add(gradeLeaoJS);
    unitOfWork.Grades.Add(gradeLeaoSQL);
    //unitOfWork.Grades.Add(gradeLeaoCS, gradeLeaoJS, gradeLeaoSQL);

    unitOfWork.Complete();
}

//using (var context = new SchoolContext())
//{
//    context.Database.Migrate();

//    var unitOfWork = new UnitOfWork(context);

//    var student = new Student { Name = "Rafael Leao" };
//    unitOfWork.Students.Add(student);

//    var subject = new Subject { Name = "CSharp" };
//    unitOfWork.Subjects.Add(subject);

//    var grade = new Grade { Student = student, Subject = subject, Value = 99 };
//    unitOfWork.Grades.Add(grade);

//    unitOfWork.Complete();
//}
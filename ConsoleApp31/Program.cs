using ConsoleApp31.data;
using ConsoleApp31.entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp31
{
    internal class Program
    {
        static void Main(string[] args)
        {
           appdbcontext appdbcontext = new appdbcontext();
            #region explicit loading
            //extra trip


            //var department = (from d in appdbcontext.department
            //                      where d.id == 1
            //                      select d).FirstOrDefault();
            //    Console.WriteLine($"{department.name}");

            //appdbcontext.Entry(department).Reference(nameof(department.ins_id)).Load();
            #endregion
            #region eager loading
            //var student =(from s in appdbcontext.students.Include(s => s.department    ).ThenInclude(d => d.manager)
            //              where s.id == 1   
            //              select s).FirstOrDefault();
            //Console.WriteLine($"{student?.fname},{student?.department?.name}");
            #endregion
            #region lazy loading
            //var student = (from s in appdbcontext.students
            //               where s.id == 1
            //               select s).FirstOrDefault();
            //Console.WriteLine($"{student?.fname},{student?.department?.name}");

            #endregion
            #region tracking
            //appdbcontext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //var student =(from s in appdbcontext.students
            //              where s.id==2
            //              select s).AsNoTracking().FirstOrDefault(); 
            #endregion
            #region mapping view
            // var result = appdbcontext.Set<studentdepartment>().FromSqlRaw("select * from departmentstudent");
            #endregion
        }
    }
}
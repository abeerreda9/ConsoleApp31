using ConsoleApp31.data;
using ConsoleApp31.entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp31
{
    internal class Program
    {
        static void Main(string[] args)
        {
           //appdbcontext appdbcontext = new appdbcontext();
            #region join[inner]
            //query syntax
            //var result = from s in appdbcontext.students
            //             join d in appdbcontext.department
            //             on s.dept_id equals d.id

            //             select new
            //             {
            //                 stname = s.fname,
            //                 deptname = d.name
            //             };
            //fluent synta
            //var result = appdbcontext.students.Join(appdbcontext.department, s => s.dept_id, d => d.id,
            //                                  (s, d) => new 
            //                                  {stname=s.fname,
            //                                  deptname=d.name,
            //                                  });
            #endregion
            #region group join
            #region example 1
            //var result = appdbcontext.department.GroupJoin(appdbcontext.students, d => d.id, s => s.dept_id, (d, s) => new
            //{
            //  department=d,
            //  student=s
            //});
            //var result = from d in appdbcontext.department
            //             join s in appdbcontext.students
            //             on d.id equals s.dept_id into groups
            //             select new
            //             {
            //                 department = d,
            //                 students = groups
            //             };
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.department.name);
            //    foreach (var item1 in item.student)
            //    {
            //        Console.WriteLine($"{item1.name}");
            //    }
            //}
            #endregion
            #region example 2
            //var result = appdbcontext.department.GroupJoin(appdbcontext.students, d => d.id, s => s.dept_id, (d, s) => new
            //{
            //    department = d,
            //    student = s
            //}).Where(a => a.student.Count() > 1);
            //var result = from d in appdbcontext.department
            //             join s in appdbcontext.students
            //             on d.id equals s.dept_id into groups
            //             select new { department = d, student = groups } into groups
            //             where groups.student.Count() > 1
            //             select groups;



            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.department.name);
            //    foreach(var item2 in item.student)
            //    {
            //        Console.WriteLine($"{item2.fname}");
            //    }
            //}
            #endregion

            #endregion
            #region cross join
            //var result = from s in appdbcontext.students
            //             from d in appdbcontext.department
            //             select new
            //             {
            //                 s.fname,
            //                 d.name
            //             };
            //result = appdbcontext.students.SelectMany(s => appdbcontext.department.Select(d => new
            //{
            //    s.fname,
            //    d.name
            //}));
            //foreach (var item in result) {
            //    Console.WriteLine(item);
            //}

            #endregion
            using NorthwindContext context = new NorthwindContext();
            //1.execute select statement:from sql row,from sql interpolated
            //from sql row
            int count = 3;
            var categories = context.Categories.FromSqlRaw("select * from categories");
            // categories = context.Categories.FromSqlRaw("select top({10})*from categories", count);
            //from sql interpolated
            categories = context.Categories.FromSqlInterpolated($"select * from categories");
            //2.execure dml statement[insert,update,delete]
            //execute sqlrow
            var result = context.Database.ExecuteSqlRaw("update categories\r\nset CategoryName='abeer' \r\n where categoryID=6");
            result = context.Database.ExecuteSqlInterpolated($"update categories\r\nset CategoryName='abeer' \r\n where categoryID=5");
            Console.WriteLine(result);
            // var categories=context.Categories.ToList();
            //foreach (var item in categories)
            //{
            //    Console.WriteLine(item.CategoryName);
            //}
            //check locally first[cache app ]
           if( context.Products.Local.Any(p => p.UnitsInStock == 0));
            Console.WriteLine("out of stock");
            if (context.Products.Any(p => p.UnitsInStock == 0)) ;
            //each time will send request to server database to check if at least one product out ofstock




        }
    }
}
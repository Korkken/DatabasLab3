using DatabasLab3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasLab3.Methods
{
    internal class getRecentGrades
    {
        public void GetRecentGrades()
        {
            HighschoolContext highschoolContext = new HighschoolContext();
            var lastMonth = DateOnly.FromDateTime(DateTime.Now).AddMonths(-1);

            var recentGrades = from g in highschoolContext.Grades
                               join p in highschoolContext.People
                                   on g.PersonId equals p.PersonId
                               where g.GradeDate >= lastMonth
                               orderby g.GradeDate descending
                               select new
                               {
                                   Student = p,
                                   Grade = g,
                                   Course = g.Course
                               };

            foreach (var item in recentGrades)
            {
                Console.WriteLine($"Elev: {item.Student.FirstName} {item.Student.LastName}");
                Console.WriteLine($"Klass: {item.Course.CourseName}");
                Console.WriteLine($"Betyg: {item.Grade.Grade1}");
                Console.WriteLine("------------------------");
            }
        }
    }
}

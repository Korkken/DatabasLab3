using DatabasLab3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasLab3.Methods
{
    internal class getAverageGrade
    {
        public void GetAverageGrade()
        {
            HighschoolContext highschoolContext = new HighschoolContext();
            var averageGrade = from g in highschoolContext.Grades
                               join c in highschoolContext.Classes
                                   on g.CourseId equals c.ClassId
                               group g by new { c.ClassName } into gGroup
                               select new
                               {
                                   ClassName = gGroup.Key.ClassName,
                                   AverageGrade = gGroup.Average(g => g.Grade1)
                               };

            foreach (var item in averageGrade)
            {
                Console.WriteLine($"Klass: {item.ClassName}");
                Console.WriteLine($"Medelbetyget i klassen: {item.AverageGrade:F2}"); // Rounds to 2 decimal places
                Console.WriteLine("------------------------");
            }
        }
    }
}

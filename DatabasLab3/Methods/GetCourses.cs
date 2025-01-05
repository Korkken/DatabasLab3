using DatabasLab3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasLab3.Methods
{
    internal class GetCourses
    {
        public void getCourses() 
        {
            HighschoolContext highschoolContext = new HighschoolContext();


            foreach (var item in highschoolContext.Courses.Where(c => c.Activity == "Aktiv"))
            {
                Console.WriteLine($"Klass: {item.CourseName}");
                Console.WriteLine("------------------------");
            }
        }
    }
}

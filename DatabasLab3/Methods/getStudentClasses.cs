using DatabasLab3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasLab3.Methods
{
    internal class getStudentClasses
    {
        public void GetStudentClasses()
        {
            HighschoolContext highschoolContext = new HighschoolContext();
            foreach (var item in highschoolContext.Classes)
            {
                Console.WriteLine(item.ClassName);
            }

            Console.WriteLine("Vilken klass vill du hämta alla elever ifrån?");
            var inputClass = Console.ReadLine();

            var studentsInClass = highschoolContext.Classes //Hämtar ut alla elever från klassen som är vald
                .Where(c => c.ClassName == inputClass)
                .SelectMany(c => c.Students)
                .Where(s => s.Role == "Elev");

            foreach (var student in studentsInClass) //Skriver ut alla elever från klassen som är vald
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
                Console.WriteLine("--------------");
            }
        }
    }
}

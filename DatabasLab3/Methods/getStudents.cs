using DatabasLab3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasLab3.Methods
{
    internal class getStudents
    {
        public void GetStudents()
        {
            HighschoolContext highschoolContext = new HighschoolContext();
            foreach (var item in highschoolContext.People.Where(p => p.Role == "Elev"))
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.Role}");
                Console.WriteLine("-----------");
            }
        }
    }
}

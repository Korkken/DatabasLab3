using DatabasLab3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasLab3.Methods
{
    
    internal class getPeople
    {

       public void GetPeople()
        {
            HighschoolContext highschoolContext = new HighschoolContext();
            Console.WriteLine("Vad vill du hämta ut? 1. Elev, 2. Rektor, 3. Lärare, 4. Alla");
            var inputAssignment = "";
            var input = 0;

            if (int.TryParse(Console.ReadLine(), out input)) //Ändrar variabeln baserat på användarens input
            {
                switch (input)
                {
                    case 1:
                        inputAssignment = "Elev";
                        break;
                    case 2:
                        inputAssignment = "Rektor";
                        break;
                    case 3:
                        inputAssignment = "Lärare";
                        break;
                    case 4:
                        inputAssignment = "Alla";
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val");
                        return;
                }

                if (inputAssignment == "Alla") //Skriver ut personer baserat på vad användaren har valt tidigare.
                {
                    foreach (var item in highschoolContext.People)
                    {
                        Console.WriteLine($"{item.FirstName} {item.LastName} {item.Role}");
                        Console.WriteLine("-----------");
                    }
                }
                else
                {
                    foreach (var item in highschoolContext.People.Where(p => p.Role == inputAssignment))
                    {
                        Console.WriteLine($"{item.FirstName} {item.LastName} {item.Assignment}");
                        Console.WriteLine("-----------");
                    }
                }
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning. Ange ett nummer mellan 1-4.");
            }
        }
    }
}

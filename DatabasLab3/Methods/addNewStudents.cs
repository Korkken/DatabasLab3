using DatabasLab3.Data;
using DatabasLab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasLab3.Methods
{
    internal class addNewStudents
    {
        public void AddNewStudent()
        {
            HighschoolContext highschoolContext = new HighschoolContext();
            Console.WriteLine("Skriv in elevens information");

            Console.Write("Namn: ");
            string firstName = Console.ReadLine();

            Console.Write("Efternamn: ");
            string lastName = Console.ReadLine();

            Console.Write("Personnummer (12 siffror): ");
            string personalNumber = Console.ReadLine();

            var newStudent = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Ssn = personalNumber,
                Role = "Elev",
                Assignment = "Elev"
            };

            try
            {
                highschoolContext.People.Add(newStudent);
                highschoolContext.SaveChanges();

                Console.WriteLine("Eleven är Tillagd i databasen");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ett fel uppstod med att lägga till eleven: {ex.Message}");
            }
        }

    }
}

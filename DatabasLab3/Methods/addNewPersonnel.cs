using DatabasLab3.Data;
using DatabasLab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasLab3.Methods
{
    internal class addNewPersonnel
    {
        public void AddNewPersonnel()
        {
            HighschoolContext highschoolContext = new HighschoolContext();
            Console.WriteLine("Skriv in elevens information");

            Console.WriteLine("Namn: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Efternamn: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Vad för roll ska personen ha? Skriv Rektor eller Lärare");
            string PersonRole = Console.ReadLine();

            Console.WriteLine("Personnummer (12 siffror): ");
            string personalNumber = Console.ReadLine();

            var newPersonnel = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Ssn = personalNumber,
                Role = PersonRole,
                Assignment = "Elev"
            };

            try
            {
                highschoolContext.People.Add(newPersonnel);
                highschoolContext.SaveChanges();

                Console.WriteLine($"Du har lagt till en ny {PersonRole} i databasen");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ett fel uppstod med att lägga till {PersonRole}: {ex.Message}");
            }
        }
    }
}

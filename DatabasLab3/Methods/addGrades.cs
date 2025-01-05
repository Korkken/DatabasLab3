using DatabasLab3.Data;
using DatabasLab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DatabasLab3.Methods
{
    internal class addGrades
    {
        public void AddGrades() //DENNA KOD FUNKAR INTE MEN LÄMNAR KVAR DET ÄNDÅ OCH KÖRDE DET I SSMS BARA
        {
            HighschoolContext highschoolContext = new HighschoolContext();
            Console.WriteLine("Skriv in elevens information");
            int StudentId;
            int CourseId;
            int Grade;
            int TeacherId;
            DateOnly Date;
            Console.Write("Elevens ID: ");
            int.TryParse(Console.ReadLine(), out StudentId);

            Console.Write("Kursens ID: ");
            int.TryParse(Console.ReadLine(), out CourseId);

            Console.Write("Betyg: ");
            int.TryParse(Console.ReadLine(), out Grade);

            Console.Write("Lärarens ID: ");
            int.TryParse(Console.ReadLine(), out TeacherId);

            Console.Write("Datum då betyget sattes (YEAR-MM-DD): ");
            DateOnly.TryParse(Console.ReadLine(), out Date);

            var newGrade = new Grade  //skapar nytt objekt som ska skickas in i databasen
            {
                PersonId = StudentId,
                CourseId = CourseId,
                Grade1 = Grade,
                GradeDate = Date,
                TeacherId = TeacherId
            };

            try
            {
                highschoolContext.Grades.Add(newGrade);
                highschoolContext.SaveChanges();  //skickar in i databasen

                Console.WriteLine("Betyget är tillagt i databasen");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ett fel uppstod med att lägga till eleven: {ex.Message}");
            }
        }
    }
}

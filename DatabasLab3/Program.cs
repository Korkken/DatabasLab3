// See https://aka.ms/new-console-template for more information
using DatabasLab3.Data;
using DatabasLab3.Models;
using Microsoft.EntityFrameworkCore;
using DatabasLab3.Methods;
HighschoolContext highschoolContext = new HighschoolContext();

getPeople GetPeople = new getPeople();
getStudents GetStudents = new getStudents();
getRecentGrades getRecentGrades = new getRecentGrades();
getAverageGrade getAverageGrade = new getAverageGrade();
getStudentClasses getStudentClasses = new getStudentClasses();
addNewPersonnel addNewPersonnel = new addNewPersonnel();
addNewStudents addNewStudents = new addNewStudents();
GetCourses getCourses = new GetCourses();
addGrades addGrades = new addGrades();
Console.WriteLine("Vad skulle du vilja göra?\n 1. Hämta personer\n 2. Hämta elever\n 3. Hämta senaste betygen\n 4. Hämta genomsnittliga betygen\n" +
    " 5. Hämta klasser\n 6. Lägg till ny personal\n 7. Lägg till ny elev \n 8. Hämta Lärare \n 9. Sätt betyg på någon elev.(funkar ej men lämnade kvar koden)");
var input = 0;
int.TryParse(Console.ReadLine(), out input);

switch(input)
{
    case 1:
        GetPeople.GetPeople();
        break;
    case 2:
        GetStudents.GetStudents();
        break;
    case 3:
        getRecentGrades.GetRecentGrades();
        break;
    case 4:
        getAverageGrade.GetAverageGrade();
        break;
    case 5: 
        getStudentClasses.GetStudentClasses();
        break;
    case 6: 
        addNewPersonnel.AddNewPersonnel();
        break;
    case 7:
        addNewStudents.AddNewStudent();
        break;
    case 8:
        getCourses.getCourses();
        break;
    case 9:
        addGrades.AddGrades();
        break;


}











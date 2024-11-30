using PB303_ADONet.Contexts;
using PB303_ADONet.Models;
using PB303_ADONet.Services.Implementations;

namespace PB303_ADONet;

internal class Program
{
    static void Main(string[] args)
    {
        StudentService studentService = new StudentService();


        //studentService.CreateTable();

        //Student student = new()
        //{
        //    Fullname = "Aslan",
        //    Grade = 50
        //};

        //studentService.Create(student);

        //var students = studentService.GetAll();


        //foreach (var student in students)
        //{
        //    Console.WriteLine(student);
        //}


        //Console.WriteLine("Id daxil edin");
        //int id = int.Parse(Console.ReadLine());

        //var student = studentService.GetById(id);

        //if (student is { })
        //    Console.WriteLine(student);

        restart:
        Console.WriteLine("Hansi studenti update etmek isteyirsiniz");
        int id=int.Parse(Console.ReadLine());

        var student=studentService.GetById(id);

        if(student is null)
        {
            Console.WriteLine("Student movcud deyil");
            goto restart;
        }

        Console.WriteLine("enter new fullname");
        string fullname=Console.ReadLine();
        Console.WriteLine("Enter new grade");
        int grade=int.Parse(Console.ReadLine());

        student.Fullname = fullname;
        student.Grade = grade;

        //Student updatedStudent = new Student()
        //{
        //    Id = 1,
        //    Fullname = "Gunel new",
        //    Grade = 19
        //};

        studentService.Update(student);
    }
}

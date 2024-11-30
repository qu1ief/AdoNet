using PB303_ADONet.Contexts;
using PB303_ADONet.Exceptions;
using PB303_ADONet.Models;
using PB303_ADONet.Services.Interfaces;
using System.Data;

namespace PB303_ADONet.Services.Implementations;

public class StudentService : IStudentService
{

    public void Create(Student student)
    {
        var result = AppDBContext.ExecuteCommand($"insert into Students values ('{student.Fullname}',{student.Grade})");

        if (result > 0)
            Console.WriteLine("Student succesffully created");
    }

    public void Delete(Student student)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetAll()
    {
        var dataTable = AppDBContext.ExecuteQuery("select*from Students");

        List<Student> students = new List<Student>();

        foreach (DataRow item in dataTable.Rows)
        {
            Student student = new Student()
            {
                Id = (int)item["Id"],
                Fullname = item["Fullname"].ToString(),
                Grade = (int)item["Grade"]
            };

            students.Add(student);
        }

        return students;
    }

    public Student GetById(int id)
    {
        var students = GetAll();

        var student = students.FirstOrDefault(x => x.Id == id);

        if (student is null)
            throw new NotFoundException();

        return student;
    }

    public void Update(Student student)
    {
        var existStudent = GetById(student.Id);

        if (existStudent is null)
            throw new NotFoundException();


        var result = AppDBContext.ExecuteCommand($"update Students set Fullname='{student.Fullname}' , Grade={student.Grade} where Id={student.Id}");


        if (result > 0)
            Console.WriteLine("Student succesffuly updated");


    }

    public void CreateTable()
    {
        var result = AppDBContext.ExecuteCommand("create table Students(" +
              "Id int primary key identity(1,1)," +
              "Fullname nvarchar(64) not null," +
              "Grade int check(Grade between 0 and 100))");


        if (result > 0)
            Console.WriteLine("Table successfully created");
    }
}

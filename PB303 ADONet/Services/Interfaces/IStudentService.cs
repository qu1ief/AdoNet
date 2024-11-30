using PB303_ADONet.Models;

namespace PB303_ADONet.Services.Interfaces;

public interface IStudentService
{
    void Create(Student student);
    void Update(Student student);
    void Delete(Student student);
    List<Student> GetAll();
    Student GetById(int id);

}

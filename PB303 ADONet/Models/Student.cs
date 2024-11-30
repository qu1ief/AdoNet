namespace PB303_ADONet.Models;

public class Student
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public int Grade { get; set; }



    public override string ToString()
    {
        return $"{Id} {Fullname} {Grade}";
    }
}

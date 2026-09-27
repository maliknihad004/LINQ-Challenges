using System;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }
}

class LevelTwo
{
    public static void Main(string[] args)
    {
        var students = new List<Student>
        {
            new Student { Name = "Malik", Age = 22, Grade = 90 },
            new Student { Name = "Abd", Age = 22, Grade = 92 },
            new Student { Name = "Adham", Age = 28, Grade = 70 }
        };

        var topStudents = students.Where(student => student.Age > 20 && student.Grade >= 80);

        Console.WriteLine("Students older than 20 with a grade of 80 or higher:");

        foreach (var student in topStudents)
        {
            Console.WriteLine(student.Name);
        }

        var studentInformation = students.GroupBy(student => student.Age)
                                         .Select(group => new
            {
                studentAge = group.Key,
                numberOfStudents = group.Count(),
                averageGrade = group.Average(student => student.Grade)
            });

        foreach (var group in studentInformation)
        {
            Console.WriteLine($"Age: {group.studentAge}, Students: {group.numberOfStudents}, Average: {group.averageGrade}");
        }
            
    }
}

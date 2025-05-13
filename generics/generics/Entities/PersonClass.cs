using System;

namespace generics.Entities;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Student : Person
{
    public void SubmitWork()
    {
        Console.WriteLine($"{Name} has submitted work.");
    }

    public void SayName()
    {
        Console.WriteLine($"Name: {Name}.");
    }
}

public class Teacher : Person
{
    public void GradeStudent(Student student, byte grade)
    {
        Console.WriteLine($"Name: {student.Name} grade: {grade}.");
    }

    public void ExpelStudent(Student student)
    {
        Console.WriteLine($"{Name} has expelled {student.Name}.");
    }

    public void ShowPresentStudents(IEnumerable<Student> students)
    {
        Console.WriteLine("Present students:");
        foreach (var student in students)
        {
            Console.WriteLine(student.Name);
        }
    }
}
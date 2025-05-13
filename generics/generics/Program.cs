//Сіверин Олександр КП-41
using generics.Entities.Hierarhy;
using generics.Entities;
using generics.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        var faculty = new Faculty { Id = 1, Name = "FPM" };
        var group1 = new Group { Id = 1, Name = "КП-41" };
        var group2 = new Group { Id = 2, Name = "КП-42" };
        var group3 = new Group { Id = 3, Name = "КП-43" };

        faculty.AddGroup(group1);
        faculty.AddGroup(group2);
        faculty.AddGroup(group3);

        var student1 = new Student { Id = 1, Name = "Student A" };
        var student2 = new Student { Id = 2, Name = "Student B" };
        var student3 = new Student { Id = 3, Name = "Student C" };
        var student4 = new Student { Id = 4, Name = "Student D" };
        var student5 = new Student { Id = 5, Name = "Student E" };
        var student6 = new Student { Id = 6, Name = "Student F" };

        faculty.AddStudentToGroup(1, student1);
        faculty.AddStudentToGroup(1, student2);
        faculty.AddStudentToGroup(2, student3);
        faculty.AddStudentToGroup(2, student4);
        faculty.AddStudentToGroup(3, student5);
        faculty.AddStudentToGroup(3, student6);

        Console.WriteLine("list of students in group КП-41:");
        foreach (var student in faculty.GetAllStudentsInGroup(1))
        {
            Console.WriteLine(student.Name);
        }

        Console.WriteLine("list of students in group КП-42:");
        foreach (var student in faculty.GetAllStudentsInGroup(2))
        {
            Console.WriteLine(student.Name);
        }

        Console.WriteLine("list of students in group КП-43:");
        foreach (var student in faculty.GetAllStudentsInGroup(3))
        {
            Console.WriteLine(student.Name);
        }

        // IReadOnlyRepository<Student,int> studRepo = new InMemoryRepository<Student,int>();
        // IReadOnlyRepository<Person,int>  persRepo = studRepo;  // має компілюватися

        // IWriteRepository<Person,int> persWrite = new InMemoryRepository<Student,int>(); 
        // IWriteRepository<Student,int> studWrite = persWrite;  // має компілюватися

    }



}


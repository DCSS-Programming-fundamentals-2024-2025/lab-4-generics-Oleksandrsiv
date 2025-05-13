using System;
using generics.Entities;
using generics.Interfaces;


namespace generics.Entities.Hierarhy;

public class Faculty
{
    public int Id { get; set; }
    public string Name { get; set; }
    private IRepository<Group, int> _groups = new InMemoryRepository<Group, int>();

    public void AddGroup(Group g)
    {
        _groups.Add(g.Id, g);
    }

    public void RemoveGroup(int id)
    {
        _groups.Remove(id);
    }

    public IEnumerable<Group> GetAllGroups()
    {
        return _groups.GetAll();
    }

    public Group GetGroup(int id)
    {
        return _groups.Get(id);
    }

    public void AddStudentToGroup(int groupId, Student s)
    {
        var group = GetGroup(groupId);
        group.AddStudent(s);
    }

    public void RemoveStudentFromGroup(int groupId, int studentId)
    {
        var group = GetGroup(groupId);
        group.RemoveStudent(studentId);
    }

    public IEnumerable<Student> GetAllStudentsInGroup(int groupId)
    {
        var group = GetGroup(groupId);
        return group.GetAllStudents();
    }

    public Student FindStudentInGroup(int groupId, int studentId)
    {
        var group = GetGroup(groupId);
        return group.FindStudent(studentId);
    }
}
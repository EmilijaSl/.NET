using _1Pamoka_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class DataBaseRepository:IDataBaseRepository
    {
        private List<Student> _students = new List<Student>
        {
            new Student() { Department = ".Net", Id = 1, Name = "Vardenis" },
            new Student() { Department = "Front End", Id = 2, Name = "Jonaitis" }
        };

    
      
        public IEnumerable<Student> GetStudentsFromDatabase()
        { 
        return _students;
        }
        public Student GetStudentById(int id) => _students.FirstOrDefault(x => x.Id == id);
        public void UpdateStudentInDatabase(Student student)
        {
            var studentFromDb = GetStudentById(student.Id);
            studentFromDb.Name = student.Name;
            studentFromDb.Department = student.Department;
        }
        public void AddStudentToDatabase(Student student)
        {
            _students.Add(student);
        }
        public void DeleteStudent(int id)
        {
            var studentToRemove = GetStudentById(id);
            _students.Remove(studentToRemove);
        }
    }
}

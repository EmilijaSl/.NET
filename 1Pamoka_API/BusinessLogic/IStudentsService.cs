using _1Pamoka_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetAllStudents();
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        Student GetStudentById(int id);
        void DeleteStudent(int id);


    }
}

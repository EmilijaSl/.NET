using _1Pamoka_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public interface IDataBaseRepository
    {
        IEnumerable<Student> GetStudentsFromDatabase();
        void AddStudentToDatabase(Student student); //kuriam metoda priimam studenta kaip argumenta (implementuosimes repozitorijoje
        void UpdateStudentInDatabase(Student student);
        Student GetStudentById(int id);
        void DeleteStudent(int id);


    }
}

using _1Pamoka_API.Models;
using DataAcces;
using RandomNumberService;

namespace BusinessLogic
{
    public class StudentsService : IStudentsService
    {
        private IDataBaseRepository _dataBaseRepository;

        public StudentsService(IDataBaseRepository dataBaseRepository, IRandomNumberGenerator randomNumberGenerator)
        { 
        _dataBaseRepository = dataBaseRepository;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return _dataBaseRepository.GetStudentsFromDatabase();
        }
        public Student GetStudentById(int id)
        {
            return _dataBaseRepository.GetStudentById(id);
        }
        public void AddStudent(Student student)
        {
            _dataBaseRepository.AddStudentToDatabase(student);
        }
        public void UpdateStudent(Student student)
        { 
        var studentFromDb=_dataBaseRepository.GetStudentById(student.Id);
            if (studentFromDb == null)
            {
                throw new ArgumentException($"Couldn't find student by Id {student.Id}");
            }
            _dataBaseRepository.UpdateStudentInDatabase(student);
        }
  
        public void DeleteStudent(int id)
        {
         _dataBaseRepository.DeleteStudent(id);
        }
      
    }
}
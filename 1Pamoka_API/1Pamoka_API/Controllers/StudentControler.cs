using _1Pamoka_API.Models;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomNumberService;

namespace _1Pamoka_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentControler : ControllerBase
    {
        private IStudentsService _studentsService;
        public StudentControler(IStudentsService studentsService, IRandomNumberGenerator randomNumberGenerator) //konstruktorius kuri kuriame butent siai klasei
        { 
        _studentsService = studentsService; //priskiriame nauja objekta 
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var allStudents = _studentsService.GetAllStudents();
            return Ok(allStudents);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var studentWithId = _studentsService.GetStudentById(id);
            return Ok(studentWithId);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            _studentsService.AddStudent(student);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
          _studentsService.UpdateStudent(student);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            _studentsService.DeleteStudent(id);
            return Ok();
        }


    }

}

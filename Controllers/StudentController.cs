using Microsoft.AspNetCore.Mvc;
using NetCoreTestInnovar.BusinessService;
using NetCoreTestInnovar.Models;

namespace NetCoreTestInnovar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController
    {
        private StudentBusinessService _studentBusinessService;

        public StudentController(StudentBusinessService studentBusinessService){
            _studentBusinessService = studentBusinessService;
        }

        [HttpGet("[action]")]
        public List<Student> GetStudents(){
            return _studentBusinessService.GetStudents();
        }

        [HttpGet("[action]")]
        public Student GetStudent(long Id){
            return _studentBusinessService.GetStudent(Id);
        }
        
        [HttpPost("[action]")]
        public Student CreateStudent(Student student){
            return _studentBusinessService.CreateStudent(student);
        }

        [HttpGet("[action]")]
        public string GetOlderStudent(){
            return _studentBusinessService.GetOlderStudent();

        }
        [HttpGet("[action]")]
        public List<Student> GetStudentsBornThisMonth(){
            return _studentBusinessService.GetStudentsBornThisMonth();
        }
        [HttpGet("[action]")]
        public List<string> GetCoursesByStudentId(long StudentId){
            return _studentBusinessService.GetCoursesByStudentId(StudentId);
        }

        [HttpPost("[action]")]
        public List<Student> GetStudentsByIds(List<long> studentIds){
            return _studentBusinessService.GetStudentsByIds(studentIds);
        }
        [HttpGet("[action]")]
        public List<int> GetEvenScoresByStudentId(long studentId){
            return _studentBusinessService.GetEvenScoresByStudentId(studentId);
        }
        [HttpGet("[action]")]
        public List<Student> GetStudentsByNameOrLastName(string word){
            return _studentBusinessService.GetStudentsByNameOrLastName(word);
        }

    }
}
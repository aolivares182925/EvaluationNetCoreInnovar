using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreTestInnovar.DataService;
using NetCoreTestInnovar.Models;

namespace NetCoreTestInnovar.BusinessService
{
    public class StudentBusinessService
    {
        private StudentDataService _studentDataService;

        public StudentBusinessService(StudentDataService studentDataService){
            _studentDataService = studentDataService;
        }

        public List<Student> GetStudents(){
            return _studentDataService.GetStudents();
        }
        public Student GetStudent(long Id){
            return _studentDataService.GetStudent(Id);
        }

        public Student CreateStudent(Student student){
            return _studentDataService.CreteStudent(student);
        }
        public string GetOlderStudent(){
            return _studentDataService.GetOlderStudent().Name;

        }
        public List<Student> GetStudentsBornThisMonth(){
            var actual = DateTime.Now.Month;
            var listStudents = GetStudents();
            return listStudents.Where(student => student.BirthDate.Month == actual).ToList(); 
        }

        public List<string> GetCoursesByStudentId(long StudentId){
            return _studentDataService.GetCoursesByStudentId(StudentId);
        }
        public List<Student> GetStudentsByIds(List<long> studentIds){
            return _studentDataService.GetStudentsByIds(studentIds);
        }
        public List<int> GetEvenScoresByStudentId(long studentId){
            return _studentDataService.GetEvenScoresByStudentId(studentId);
        }
        public List<Student> GetStudentsByNameOrLastName(string word){
            return _studentDataService.GetStudentsByNameOrLastName(word);
        }


        
    }
}
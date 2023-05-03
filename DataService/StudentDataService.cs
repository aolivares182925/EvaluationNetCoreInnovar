using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarApi.Models;
using NetCoreTestInnovar.Models;
using Microsoft.EntityFrameworkCore;

namespace NetCoreTestInnovar.DataService
{
    public class StudentDataService
    {
        private Context _context;
        public StudentDataService(Context context){
            _context = context;
        }

        public List<Student> GetStudents(){
            return _context.Students.Include(S => S.Scores).ToList();
        }
        public Student GetStudent(long Id){
            return _context.Students.Find(Id);
        }

        public Student CreteStudent(Student student){
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }
        public Student GetOlderStudent(){
            List<Student> liststudent = GetStudents();
            Student mayor = new Student();
            DateTime mas_antigua = new DateTime(2050, 8, 1, 0, 0, 0);
            
            foreach(Student student in liststudent){
                if(DateTime.Compare(student.BirthDate,mas_antigua) < 0){
                    mayor = student;
                    mas_antigua = student.BirthDate;
                }
            }
            return mayor;
        }
        //Obtener los Cursos de un estudiante
	    public List<string> GetCoursesByStudentId(long StudentId){
            //List<Course> Cursos = _context.Course.ToList();
 
            var JoinStudent_Courses = (
                from student in _context.Students
                join score in _context.Scores
                on student.Id equals score.StudentId
                join course in _context.Course
                on score.CourseId equals course.Id
                where student.Id == StudentId
                select new
                {
                    CourseID = score.CourseId,
                    CourseName = course.Name
                }
            ).ToList();
            

            List<string> cursos = new List<string>();
            foreach(var curso in JoinStudent_Courses){
                if(!cursos.Contains(curso.CourseName))
                    cursos.Add(curso.CourseName);
            }
            return cursos;

            //return Cursos.Where(curso => cursos.Contains(curso.Name)).ToList();

        }
        //Obtener los estudiantes por una lista de ids
	    public List<Student> GetStudentsByIds(List<long> studentIds){
            List<Student> students = new List<Student>();

            foreach(long id in studentIds){
                students.Add(GetStudent(id));
            }   
                        
            return students; 
            // _context.Students.Include(S => S.Scores).ToList();

        }
        //Obtener las notas pares de un alumno:
	    public List<int> GetEvenScoresByStudentId(long studentId){
            List<int> notas_pares = new List<int>();
            var Join_Student_score = (
                from student in _context.Students
                join score in _context.Scores
                on student.Id equals score.StudentId
                where student.Id == studentId
                select new
                {
                    Nota = score.Puntuation                    
                }
            ).ToList();


            foreach(var score in Join_Student_score){
                if((score.Nota % 2) == 0 && (score.Nota != 0)){
                    notas_pares.Add(score.Nota);
                }
            }
            return notas_pares;
        }
        //Obtener los estudiantes que tengan en su nombre o apellido una palabra
	    public List<Student> GetStudentsByNameOrLastName(string word){
            // List<Student> students = new List<Student>();
            return _context.Students.Where(s => (s.Name == word) || (s.LastName == word)).ToList();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreTestInnovar.DataService;
using NetCoreTestInnovar.Models;

namespace NetCoreTestInnovar.BusinessService
{
    public class CourseBusinessService
    {
        private CourseDataService _courseDataService;

        public CourseBusinessService(CourseDataService courseDataService){
            _courseDataService = courseDataService;
        }

        public List<Course> GetCourses(){
            return _courseDataService.GetCourses();
        }

        public Course CreateCourse(Course course){
            return _courseDataService.CreateCourse(course);
        }

        
    }
}
using Microsoft.AspNetCore.Mvc;
using NetCoreTestInnovar.BusinessService;
using NetCoreTestInnovar.Models;

namespace NetCoreTestInnovar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController: ControllerBase
    {
        private CourseBusinessService _courseBusinessService;
        public CourseController(CourseBusinessService courseBusinessService){
            _courseBusinessService = courseBusinessService;
        }

        [HttpGet("[action]")]
        public List<Course> GetCourses(){
            return _courseBusinessService.GetCourses();
        }

        [HttpPost("[action]")]
        public Course CreateCourse(Course course){
            return _courseBusinessService.CreateCourse(course);
        }

    }
}
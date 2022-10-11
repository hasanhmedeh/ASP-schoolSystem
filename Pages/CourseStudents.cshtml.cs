using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using school.Data;
using school.services;

namespace MyApp.Namespace
{
    public class CourseStudentsModel : PageModel
    {
        private StudentService _service { get; set; }
        public CourseStudentsModel(StudentService service)
        {
            this._service = service;
        }

        [BindProperty(SupportsGet = true)]
        public int courseId { get; set; }
        public List<Student> students { get; set; }
        public Course courseInfo { get; set; }
        public void OnGet()
        {
            students = _service.getStudentForCourse(courseId);
            courseInfo = _service.getCourseById(courseId);
        }
    }
}

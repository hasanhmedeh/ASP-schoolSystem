using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using school.Data;
using school.services;

namespace MyApp.Namespace
{
    public class CoursesModel : PageModel
    {
        public StudentService _service { get; set; }
        public CoursesModel(StudentService service){
            this._service = service;
        }
        public List<Course> courses { get; set; }
        public void OnGet()
        {
            courses = _service.getAllCourses();
        }
    }
}

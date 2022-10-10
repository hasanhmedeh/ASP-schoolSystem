using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using school.Data;
using school.services;

namespace MyApp.Namespace
{
    public class StudentsModel : PageModel
    {  
        private readonly StudentService _service;
        public StudentsModel(StudentService service)
        {
            this._service = service;
        }
        [BindProperty(SupportsGet = true)]
        public int studentId { get; set; }

        public List<Student> students {get; set; }

        public void OnGet()
        {
            students = _service.getAllStudents();            
        }

        public void OnPostDelete()
        {
            _service.deleteStudent(studentId);
            students = _service.getAllStudents();
        }
    }
}

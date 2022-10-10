using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using school.Data;
using school.Pages.Bind;
using school.services;

namespace MyApp.Namespace
{
    public class NewStudentsModel : PageModel
    {
        private readonly StudentService _service;
        public NewStudentsModel(StudentService service)
        {
            this._service = service;
        }
        [BindProperty(SupportsGet = true)]
        public int studentId { get; set; }
        [BindProperty]
        public Student st { get; set; }
        [BindProperty]
        public StudentBinding Input { get; set; }
        public List<SelectListItem> courses { get; set; } = new List<SelectListItem>{
            new SelectListItem { Value="", Text="Choose courses", Disabled=true }
        };
        public List<SelectListItem> nationalities { get; set; } = new List<SelectListItem>{
            new SelectListItem { Value="", Text="Choose Nationality", Disabled=true}
        };


        public void OnGet()
        {
            courses = _service.getAllCourses(courses);
            nationalities = _service.getAllNationalities(nationalities);
        }

        public IActionResult OnGetEdit(){
            st = _service.GetStudent(studentId, courses ,nationalities);
            return Page();
        }

        public IActionResult OnPostCreate(){
            _service.createStudent(Input);
            return RedirectToPage("/Students");
        }

        public IActionResult OnPostUpdate(){
            _service.Edit(studentId, Input);
            return RedirectToPage("/Students");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using school.Pages.Bind;
using school.services;

namespace MyApp.Namespace
{
    public class NewCourseModel : PageModel
    {
        private readonly StudentService _service;
        public NewCourseModel(StudentService service)
        {
            this._service = service;
        }

        [BindProperty(SupportsGet = true)]
        public CourseBinding Input { get; set; }
        public void OnGet()
        {
        }

        public void OnPostCreate(){
            if(ModelState.IsValid){
                _service.createCourse(Input);
            }else{
                ModelState.AddModelError(string.Empty, "An error occured while adding a new course");
            }
            
        }
    }
}

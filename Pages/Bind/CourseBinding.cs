using System.ComponentModel.DataAnnotations;

namespace school.Pages.Bind
{
    public class CourseBinding
    {
        [Required]
        [Display(Name="Enter Course Name: ")]
        public string courseName { get; set; }
    }
}
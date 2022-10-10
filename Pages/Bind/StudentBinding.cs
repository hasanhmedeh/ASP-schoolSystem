using System.ComponentModel.DataAnnotations;

namespace school.Pages.Bind
{
    public class StudentBinding
    {
        [Required]
        [Display(Name="Enter Full Name: ")]
        public string studentName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name="Enter Email: ")]
        public string studentEmail { get; set; }

        [Required]
        [EmailAddress]
        [Compare("studentEmail")]
        [Display(Name="Confirm Email: ")]
        public string confirmEmail { get; set; }

        [Required]
        [Display(Name="Enter your age: ")]
        public int studentAge { get; set; }

        [Required]
        [Display(Name="Choose Gender: ")]
        public string studentGender { get; set; }

        [Required]
        [Display(Name="Choose Courses: ")]
        public List<int> CoursesIds { get; set; }

        [Required]
        [Display(Name="Choose Nationality: ")]
        public int NationalityId { get; set; }
    }
}
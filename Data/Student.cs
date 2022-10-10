using System.ComponentModel.DataAnnotations.Schema;

namespace school.Data
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int IsDeleted { get; set; }
        public ICollection<Course> Courses { get; set; }
        public Nationality Nationality { get; set; }
    }
}
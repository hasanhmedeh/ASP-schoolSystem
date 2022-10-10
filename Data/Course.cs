namespace school.Data
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int IsDeleted { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
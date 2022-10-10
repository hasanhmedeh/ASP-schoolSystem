namespace school.Data
{
    public class Nationality
    {
        public int NationalityId { get; set; }
        public string Name { get; set; }
        public int IsDeleted { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
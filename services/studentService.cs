using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school.Data;
using school.Pages.Bind;

namespace school.services
{
    public class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            this._context = context;
        }
        
        public List<Student> getAllStudents(){
            return  _context.Student.Where(n => n.IsDeleted != 1).Include(s => s.Courses).Include(s => s.Nationality).ToList();

            // return students;
        }

        public List<SelectListItem> getAllCourses(List<SelectListItem> courses){
            var allCourses = _context.Course.Where(n=>n.IsDeleted!=1).ToList();

            foreach (var course in allCourses)
            {
                var s = new SelectListItem{Value=course.CourseId.ToString(), Text=course.Name, Selected=false};
                courses.Add(s);
            }
            return courses;
        }

        public List<SelectListItem> getAllNationalities(List<SelectListItem> nationalities){
            var allNationalities = _context.Nationality.Where(n=>n.IsDeleted!=1).ToList();

            foreach (var nationality in allNationalities)
            {
                var s = new SelectListItem{Value=nationality.NationalityId.ToString(), Text=nationality.Name, Selected=false};
                nationalities.Add(s);
            }
            return nationalities;
        }

        public bool deleteStudent(int id){
            var student = _context.Student.Where(n => n.StudentId == id).Single();
            
            student.IsDeleted = 1;
            if(_context.SaveChanges() != 0){
                return true;
            } else {
                return false;
            } 
        }

        public void createStudent(StudentBinding std){
            List<Course> courses = new List<Course>{};

            foreach (var courseId in std.CoursesIds)
            {
                courses.Add(_context.Course.Where(n=>n.CourseId == courseId).Single());
            }

            Student st = new Student
            {
                Name = std.studentName,
                Email = std.studentEmail,
                Age = std.studentAge,
                Gender = std.studentGender,
                Courses = courses,
                Nationality = _context.Nationality.Where(n=>n.NationalityId == std.NationalityId).Single()
            };

            _context.Add(st);
            _context.SaveChanges();
        }

        public bool CourseExist(ICollection<Course> courses , int id )
        {
            foreach (var course in courses)
            {
                if(course.CourseId == id)
                {
                    return true;
                }
                
            }
            return false;
        }

        public Student GetStudent(int id, List<SelectListItem> courses , List<SelectListItem> nationality)
        {
            Student st = _context.Student.Where(s=>s.StudentId == id).Include(C => C.Nationality).Include(C=>C.Courses).Single();

            List<Course> c = _context.Course.ToList();

            foreach (var course in c)
            {
               
                if (CourseExist(st.Courses , course.CourseId))
                {
                    SelectListItem s = new SelectListItem()
                    {
                        Value = course.CourseId.ToString(),
                        Text = course.Name,
                        Selected = true
                    };
                    courses.Add(s);
                }
                else
                {

                    SelectListItem s = new SelectListItem()
                    {
                        Value = course.CourseId.ToString(),
                        Text = course.Name,
                        Selected = false
                    };
                    courses.Add(s);
                }
                
            }

            List<Nationality> n = _context.Nationality.ToList();

            foreach (var nationality1 in n)
            {

                if(nationality1.NationalityId == st.Nationality.NationalityId){
                    SelectListItem s = new SelectListItem()
                    {
                        Value = nationality1.NationalityId.ToString(),
                        Text = nationality1.Name,
                        Selected = true
                    };
                    nationality.Add(s);
                }
                else
                {

                    SelectListItem s = new SelectListItem()
                    {
                        Value = nationality1.NationalityId.ToString(),
                        Text = nationality1.Name,
                        Selected = false
                    };
                    nationality.Add(s);

                }

            }

            return st ;
        }

        public Student Edit(int id , StudentBinding student)
        {

            Student st = _context.Student.Where(n=> n.StudentId == id).Include(n => n.Courses).Single();

            st.Name = student.studentName;
            st.Age = student.studentAge;
            st.Gender = student.studentGender;
            st.Email = student.studentEmail;
            st.Nationality = _context.Nationality.Where(n => n.NationalityId == student.NationalityId).Select(n => n).Single();
            List<Course> courses = new List<Course>();

            foreach (var item in st.Courses)
            {
                st.Courses.Remove(item);

            }


            foreach (int Course in student.CoursesIds)
            {
                 
               st.Courses.Add(_context.Course.Where(n => n.CourseId == Course).Select(n => n).Single());

            }

            _context.SaveChanges();
            return st;
        }

        public void createCourse(CourseBinding course){
            Course newCourse = new Course{
                Name = course.courseName
            };

            _context.Add(newCourse);
            _context.SaveChanges();
        }
        
        public List<Course> getAllCourses(){
            return _context.Course.Where(n=>n.IsDeleted!=1).ToList();
        }

        public List<Student> getStudentForCourse(int id){
            Course course = _context.Course.Where(n=>n.IsDeleted!=1).Where(n=>n.CourseId == id).Include(c=>c.Students).Single();
            var students = course.Students.ToList();
            List<Student> students1 = new List<Student>();
            foreach (var student in students)
            {
                Console.WriteLine(student.IsDeleted);
                var std = _context.Student.Where(s=>s.StudentId == student.StudentId).Include(s=>s.Nationality).Single();
                if(std.IsDeleted == 0){
                    students1.Add(std);
                }
            }
            return students1;
        }

        public Course getCourseById(int id){
            return _context.Course.Where(n=>n.IsDeleted!=1).Where(n=>n.CourseId == id).Include(c=>c.Students).Single();
        }
    }

    
}
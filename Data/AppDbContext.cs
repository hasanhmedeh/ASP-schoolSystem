using Microsoft.EntityFrameworkCore;

namespace school.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> op):base(op)
        {            
        }
        public AppDbContext()
        {
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
    }
}
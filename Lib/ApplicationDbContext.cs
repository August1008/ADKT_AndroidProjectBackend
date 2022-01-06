using Lib.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lib
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { set; get; }
        public DbSet<Teacher> Teachers { set; get; }
        public DbSet<ApplicationUser> ApplicationUsers { set; get; }
        public DbSet<Class> Classes { set; get; }
        public DbSet<Enrollment> Enrollments { set; get; }
        public DbSet<Lession> Lessions { set; get; }
        public DbSet<Attendence> Attendences { set; get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Attendence>().HasKey(u => new
            {
                u.EnrollmentId,
                u.LessionId
            });
           
            base.OnModelCreating(builder);
        }

    }
}

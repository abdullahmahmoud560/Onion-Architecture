using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ApplicationDbContext
{
    public class DB:DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

      
         public DbSet<Student> students { get; set; }
         public DbSet<Subject> subjects { get; set; }
         public DbSet<StudentSubject> studentSubjects { get; set; }
    }
}

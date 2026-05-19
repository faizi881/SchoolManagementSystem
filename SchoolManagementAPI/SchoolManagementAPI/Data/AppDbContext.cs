using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<FeePayment> FeePayments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<ParentStudent> ParentStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique indexes
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.RollNumber).IsUnique();
            modelBuilder.Entity<Teacher>()
                .HasIndex(t => t.EmployeeCode).IsUnique();
            modelBuilder.Entity<Attendance>()
                .HasIndex(a => new { a.StudentId, a.Date }).IsUnique();
            modelBuilder.Entity<ParentStudent>()
                .HasIndex(ps => new { ps.ParentUserId, ps.StudentId }).IsUnique();

            // User -> Student
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> Teacher
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne(u => u.Teacher)
                .HasForeignKey<Teacher>(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Attendance -> Student
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Attendance -> Class
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Class)
                .WithMany(c => c.Attendances)
                .HasForeignKey(a => a.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            // FeePayment -> Student
            modelBuilder.Entity<FeePayment>()
                .HasOne(fp => fp.Student)
                .WithMany(s => s.FeePayments)
                .HasForeignKey(fp => fp.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // FeePayment -> Fee
            modelBuilder.Entity<FeePayment>()
                .HasOne(fp => fp.Fee)
                .WithMany(f => f.FeePayments)
                .HasForeignKey(fp => fp.FeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Grade -> Student
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Grade -> Subject
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Subject)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            // ParentStudent -> User
            modelBuilder.Entity<ParentStudent>()
                .HasOne(ps => ps.ParentUser)
                .WithMany(u => u.ParentStudents)
                .HasForeignKey(ps => ps.ParentUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ParentStudent -> Student
            modelBuilder.Entity<ParentStudent>()
                .HasOne(ps => ps.Student)
                .WithMany(s => s.ParentStudents)
                .HasForeignKey(ps => ps.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            // Additional relationships (prevent multiple cascade paths on SQL Server)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fee>()
                .HasOne(f => f.Class)
                .WithMany(c => c.Fees)
                .HasForeignKey(f => f.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subject>()
                .HasOne(su => su.Class)
                .WithMany(c => c.Subjects)
                .HasForeignKey(su => su.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subject>()
                .HasOne(su => su.Teacher)
                .WithMany(t => t.Subjects)
                .HasForeignKey(su => su.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Timetable>()
                .HasOne(tt => tt.Class)
                .WithMany(c => c.Timetables)
                .HasForeignKey(tt => tt.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Timetable>()
                .HasOne(tt => tt.Subject)
                .WithMany(su => su.Timetables)
                .HasForeignKey(tt => tt.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Timetable>()
                .HasOne(tt => tt.Teacher)
                .WithMany(t => t.Timetables)
                .HasForeignKey(tt => tt.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            // Decimal precision
            modelBuilder.Entity<Fee>()
                .Property(f => f.Amount).HasPrecision(10, 2);
            modelBuilder.Entity<FeePayment>()
                .Property(f => f.PaidAmount).HasPrecision(10, 2);
            modelBuilder.Entity<Teacher>()
                .Property(t => t.Salary).HasPrecision(10, 2);
            modelBuilder.Entity<Grade>()
                .Property(g => g.ObtainedMarks).HasPrecision(5, 2);
            modelBuilder.Entity<Grade>()
                .Property(g => g.TotalMarks).HasPrecision(5, 2);
        }
    }
}
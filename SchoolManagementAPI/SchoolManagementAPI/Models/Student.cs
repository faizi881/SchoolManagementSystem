namespace SchoolManagementAPI.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public string RollNumber { get; set; } = string.Empty;
        public int ClassId { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public DateOnly AdmissionDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public bool IsActive { get; set; } = true;

        public User User { get; set; } = null!;
        public Class Class { get; set; } = null!;
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public ICollection<FeePayment> FeePayments { get; set; } = new List<FeePayment>();
        public ICollection<ParentStudent> ParentStudents { get; set; } = new List<ParentStudent>();
    }
}
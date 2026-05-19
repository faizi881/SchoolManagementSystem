namespace SchoolManagementAPI.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public int UserId { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string? Qualification { get; set; }
        public string? Specialization { get; set; }
        public DateOnly JoiningDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public decimal? Salary { get; set; }
        public bool IsActive { get; set; } = true;

        public User User { get; set; } = null!;
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
    }
}
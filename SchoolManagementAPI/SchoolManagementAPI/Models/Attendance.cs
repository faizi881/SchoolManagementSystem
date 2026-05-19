namespace SchoolManagementAPI.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateOnly Date { get; set; }
        public string Status { get; set; } = "Present";
        public int? MarkedBy { get; set; }

        public Student Student { get; set; } = null!;
        public Class Class { get; set; } = null!;
        public User? MarkedByNavigation { get; set; }
    }
}
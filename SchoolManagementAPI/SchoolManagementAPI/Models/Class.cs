namespace SchoolManagementAPI.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public string? Section { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public ICollection<Fee> Fees { get; set; } = new List<Fee>();
        public ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
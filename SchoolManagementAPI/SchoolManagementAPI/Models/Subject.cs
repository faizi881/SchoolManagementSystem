namespace SchoolManagementAPI.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string? SubjectCode { get; set; }
        public int ClassId { get; set; }
        public int? TeacherId { get; set; }

        public Class Class { get; set; } = null!;
        public Teacher? Teacher { get; set; }
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
        public virtual ICollection<ParentStudent> ParentStudents { get; set; } = new List<ParentStudent>();
    }
}
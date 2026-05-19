namespace SchoolManagementAPI.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string? ExamType { get; set; }
        public decimal? ObtainedMarks { get; set; }
        public decimal? TotalMarks { get; set; }
        public DateOnly? ExamDate { get; set; }

        public Student Student { get; set; } = null!;
        public Subject Subject { get; set; } = null!;
    }
}
namespace SchoolManagementAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Role Role { get; set; } = null!;
        public Student? Student { get; set; }
        public Teacher? Teacher { get; set; }
        public ICollection<ParentStudent> ParentStudents { get; set; } = new List<ParentStudent>();

        // Navigation property for attendances marked by this user
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
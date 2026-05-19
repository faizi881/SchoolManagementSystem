namespace SchoolManagementAPI.Models
{
    public class Fee
    {
        public int FeeId { get; set; }
        public int ClassId { get; set; }
        public string FeeTitle { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateOnly? DueDate { get; set; }
        public string? Month { get; set; }
        public int? Year { get; set; }

        public Class Class { get; set; } = null!;
        public ICollection<FeePayment> FeePayments { get; set; } = new List<FeePayment>();
    }
}
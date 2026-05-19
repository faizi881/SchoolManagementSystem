using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.Models
{
    public class FeePayment
    {
        [Key]
        public int PaymentId { get; set; }
        public int StudentId { get; set; }
        public int FeeId { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaidDate { get; set; } = DateTime.Now;
        public string PaymentMode { get; set; } = "Cash";
        public string Status { get; set; } = "Paid";

        public Student Student { get; set; } = null!;
        public Fee Fee { get; set; } = null!;
    }
}
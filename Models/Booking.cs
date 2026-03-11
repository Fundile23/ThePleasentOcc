using System.ComponentModel.DataAnnotations;

namespace ThePleasantOcc.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        [Display(Name = "Bed Number")]
        public int BedNumber { get; set; } // 1, 2, or 3

        [Required]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string StudentEmail { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string StudentPhone { get; set; } = string.Empty;

        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        [Required]
        public string Status { get; set; } = "Active"; // "Active", "CheckedOut", "Cancelled"

        // Navigation property
        public Room? Room { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePleasantOcc.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        public string RoomNumber { get; set; } = string.Empty;

        [Required]
        public string Residence { get; set; } = string.Empty; // "single", "double", "triple", "mix"

        [Required]
        [Display(Name = "Room Type")]
        public string RoomType { get; set; } = string.Empty; // "Single", "Double", "Triple", "Mixed"

        [Required]
        [Display(Name = "Total Beds")]
        public int TotalBeds { get; set; } // 1 for Single, 2 for Double, 3 for Triple

        [Required]
        [Display(Name = "Occupied Beds")]
        public int OccupiedBeds { get; set; } = 0;

        [Required]
        public int Floor { get; set; }

        [Display(Name = "Available Beds")]
        public int AvailableBeds => TotalBeds - OccupiedBeds;

        [Display(Name = "Is Available")]
        public bool IsAvailable => OccupiedBeds < TotalBeds;

        [Display(Name = "Price Per Month")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name = "Room Size")]
        public string Size { get; set; } = "20m²";

        // Navigation property for bookings
        public ICollection<Booking>? Bookings { get; set; }
    }
}
using CustomerBooking.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerBooking.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }

        
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int RoomId { get; set; }

        [Display(Name = "Check in")]
        [Required]
        public DateTime CheckIn { get; set; }
        [Display(Name = "Check out")]
        [Required]
        public DateTime CheckOut { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace FrontDesk.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public string CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public virtual AspNetUser Customer { get; set; }
        public virtual Room Room { get; set; }
    }
}

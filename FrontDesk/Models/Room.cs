using System;
using System.Collections.Generic;

#nullable disable

namespace FrontDesk.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
            Tasks = new HashSet<Task>();
        }

        public int RoomId { get; set; }
        public int Beds { get; set; }
        public string Quality { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}

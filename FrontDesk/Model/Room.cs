using System;
using System.Collections.Generic;

#nullable disable

namespace FrontDesk.Model
{
    public partial class Room
    {
        public int Id { get; set; }
        public int Beds { get; set; }
        public DateTime AvailableTo { get; set; }
        public string Quality { get; set; }
        public decimal Price { get; set; }
        public string Clean { get; set; }
    }
}

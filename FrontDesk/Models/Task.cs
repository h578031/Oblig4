using System;
using System.Collections.Generic;

#nullable disable

namespace FrontDesk.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public int RoomId { get; set; }
        public string Employee { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }

        public virtual Room Room { get; set; }
    }
}

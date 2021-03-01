using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerBooking.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int RoomId { get; set; }

        public string Employee { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }

    }
}

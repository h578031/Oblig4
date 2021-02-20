using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerBooking.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Beds { get; set; }
        public DateTime AvailableTo {get; set;}
        [Required]
        public string quality { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal price { get; set; }
        public string clean { get; set; }


    }
}

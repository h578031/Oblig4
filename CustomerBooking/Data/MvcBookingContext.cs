using CustomerBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerBooking.Data
{
    public class MvcBookingContext : DbContext
    {
        public MvcBookingContext (DbContextOptions<MvcBookingContext> options) : base(options)
        {
        }

        public DbSet<Room> Room { get; set; }
    }
}

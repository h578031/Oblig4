using CustomerBooking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerBooking.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcBookingContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcBookingContext>>()))
            {
                //If there are any rooms then do nothing
                if(context.Room.Any())
                {
                    return;
                }

                context.Room.AddRange(
                    new Room
                    {
                        //Id = 30,
                        Beds = 3,
                        AvailableTo = DateTime.Parse("2021-3-15"),
                        quality = "Economy",
                        price = 800,
                        clean = "kind of..."
                    },
                    
                    new Room
                    {
                        //Id = 50,
                        Beds = 1,
                        AvailableTo = DateTime.Parse("2021-5-12"),
                        quality = "Wedding",
                        price = 2500,
                        clean = "was clean last week"
                    },
                    new Room
                    {
                        //Id = 70,
                        Beds = 4,
                        AvailableTo = DateTime.Parse("2021-7-9"),
                        quality = "Family",
                        price = 1000,
                        clean = "I think Liv cleaned a while ago"
                    }
                );
                context.SaveChanges();
            }
        }

    }
}

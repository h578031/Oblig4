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
            using (var context = new HotelContext(
                serviceProvider.GetRequiredService<DbContextOptions<HotelContext>>()))
            {
                //If there are any rooms then do nothing
                if(context.Room.Any() || context.Booking.Any())
                {
                    return;
                }
                context.Room.AddRange(
                    new Room
                    {
                        Beds = 3,
                        Quality = "Bronze",
                        Price = 800

                    },
                    
                    new Room
                    {
                        //Id = 50,
                        Beds = 1,
                        Quality = "Gold",
                        Price = 2500
                        
                    },
                    new Room
                    {
                        //Id = 70,
                        Beds = 4,
                        Quality = "Diamond",
                        Price = 1000
                    }
                );
                 context.Customer.AddRange(
                     new Areas.Identity.Data.Customer
                     {
                         Id = "c7353468-f881-4b8a-b27a-648ed10c158c",
                         FirstName = "Magnus",
                         LastName = "Leira",
                         PhoneNumber = "99485127",
                         Email = "magnuslei@hotmail.com",
                         PasswordHash = "780F49EE3AF87463F4350D7AACBC98D39201DD1479B897CD38D91A35B37871FC"
                     }


                     );
                context.Booking.AddRange(
                    new Booking
                    {
                        CustomerId = "c7353468-f881-4b8a-b27a-648ed10c158c",
                        RoomId = 1,
                        CheckIn = DateTime.Parse("2021-3-15"),
                        CheckOut = DateTime.Parse("2021-4-1")

                    });
                context.SaveChanges();
            }
        }

    }
}

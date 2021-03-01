using System;
using CustomerBooking.Areas.Identity.Data;
using CustomerBooking.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CustomerBooking.Areas.Identity.IdentityHostingStartup))]
namespace CustomerBooking.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HotelContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("HotelContext")));

                services.AddDefaultIdentity<Customer>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;

                })
                
                    .AddEntityFrameworkStores<HotelContext>();
            });
        }
    }
}
using CustomerBooking.Areas.Identity.Data;
using CustomerBooking.Data;
using CustomerBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerBooking.Controllers
{
    public class BookingsController : Controller
    {
        private readonly HotelContext hotelContext;

        public BookingsController(HotelContext context)
        {
            hotelContext = context;
        }
        public async Task<IActionResult> IndexAsync(string searchString)
        {
            var bookings = from b in hotelContext.Booking
                           where b.Customer.UserName == User.Identity.Name
                           select b;

            /* if (!String.IsNullOrEmpty(searchString))
             {
                 rooms = rooms.Where(x => x.Beds == int.Parse(searchString));
             }*/
            return View(await bookings.ToListAsync());
        }
        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await hotelContext.Booking
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,RoomId,CheckIn,CheckOut")] Booking booking)
        {

            Customer cust = ((Customer)(from c in hotelContext.Customer
                                        where c.UserName == User.Identity.Name
                                        select c).FirstOrDefault());
            Room room = ((Room)(from r in hotelContext.Room
                                where r.RoomId == booking.RoomId
                                select r).FirstOrDefault());
            booking.Room = room;
            booking.Customer = cust;
            booking.CustomerId = booking.Customer.Id;
            if (ModelState.IsValid)
            {
                hotelContext.Add(booking);
                await hotelContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(booking);

            
            
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await hotelContext.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId, RoomId, CheckIn, CheckOut")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            Customer cust = ((Customer)(from c in hotelContext.Customer
                                        where c.UserName == User.Identity.Name
                                        select c).FirstOrDefault());
            Room room = ((Room)(from r in hotelContext.Room
                                where r.RoomId == booking.RoomId
                                select r).FirstOrDefault());

            booking.CustomerId = cust.Id;

            if (ModelState.IsValid)
            {
                try
                {
                    hotelContext.Update(booking);
                    await hotelContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await hotelContext.Booking
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await hotelContext.Booking.FindAsync(id);
            hotelContext.Booking.Remove(booking);
            await hotelContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return hotelContext.Booking.Any(e => e.BookingId == id);
        }

    }
}

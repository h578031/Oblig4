using CustomerBooking.Data;
using CustomerBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerBooking.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HotelContext hotelContext;

        public RoomsController(HotelContext context)
        {
            hotelContext = context;
        }
        public async Task<IActionResult> IndexAsync(string searchString, string fro, string too)
        {
            var rooms = from r in hotelContext.Room
                        select r;
            

            var takenrooms = from b in hotelContext.Booking
                             join r in hotelContext.Room on b.RoomId equals r.RoomId
                             select r;

            
            if (!String.IsNullOrEmpty(fro) && !String.IsNullOrEmpty(too))
           {
                DateTime fr = DateTime.Parse(fro);
                DateTime to = DateTime.Parse(too);
                takenrooms = hotelContext.Booking.Where(x => DateTime.Compare(x.CheckIn, fr) < 0
                                                            && DateTime.Compare(x.CheckOut, to) > 0)
                                                            .Select(x => x.Room);
           }

            /*else if (!String.IsNullOrEmpty(fro))
            {
                DateTime fr = DateTime.Parse(fro);
                takenrooms = hotelContext.Booking.Where(x => DateTime.Compare(x.CheckIn, fr) < 0).Select(x => x.Room);
            }
            else if (!String.IsNullOrEmpty(too))
            {
                var takenrooms = availableRooms.Where(x => x.Beds == int.Parse(searchString));
            }*/

            var availableRooms = rooms.Where(x => takenrooms.All(y => y.RoomId != x.RoomId));

            if (!String.IsNullOrEmpty(searchString))
            {
                availableRooms = availableRooms.Where(x => x.Beds == int.Parse(searchString));
            }


            return View(await availableRooms.ToListAsync());
        }
        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await hotelContext.Room
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Beds,Quality,Price")] Room room)
        {
            if (ModelState.IsValid)
            {
                hotelContext.Add(room);
                await hotelContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await hotelContext.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Beds,AvailableTo,quality,price,clean")] Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    hotelContext.Update(room);
                    await hotelContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomId))
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
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await hotelContext.Room
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await hotelContext.Room.FindAsync(id);
            hotelContext.Room.Remove(room);
            await hotelContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return hotelContext.Room.Any(e => e.RoomId == id);
        }

    }
}

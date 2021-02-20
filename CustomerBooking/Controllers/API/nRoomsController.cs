using CustomerBooking.Data;
using CustomerBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerBooking.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Rooms")]
    public class nRoomsController : Controller
    {
        private readonly MvcBookingContext _dbContext;

        public nRoomsController(MvcBookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Room> Index()
        {
            var query = (from r in _dbContext.Room select r);

            List<Room> datalist = query.ToList<Room>();

            return datalist;
        }

    }
}

using CustomerBooking.Data;
using CustomerBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using  System.Threading.Tasks;
using System.Web.Http;

namespace CustomerBooking.Controllers.API
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/Tasks")]
    [ApiController]
    public class nTaskController : ApiController
    {
        private readonly HotelContext hotelContext;
        List<Models.Task> Tasks;
        public nTaskController(HotelContext dbContext)
        {
            hotelContext = dbContext;
            Tasks = hotelContext.Task.ToList();
        }
        [Microsoft.AspNetCore.Mvc.Route("taskInfo")]
        public IEnumerable<Models.Task> Get()
        {
            List<Models.Task> datalist = hotelContext.Task.ToList();

            return datalist;
        }

        [Microsoft.AspNetCore.Mvc.Route("post")]
        public IActionResult Post(Models.Task task)
        {
            if (!ModelState.IsValid)
            {
                return new NotFoundResult();
            }

            Request = new HttpRequestMessage();

            Models.Task t = (Models.Task)hotelContext.Task.Where(x => x.TaskId == task.TaskId).Single();
            t.Status = task.Status;
            t.Note = task.Note;
            hotelContext.SaveChanges();
            return new OkObjectResult(t);
        }


    }
}

using ApiMap.Repository;
using ApiMap.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {

        MapDbContext _context = new MapDbContext();

        // POST api/<MapController>
        [HttpPost]
        public Message Post([FromBody] Mapaddress mapAddress)
        {
            var message = new Message();
            if (ModelState.IsValid)
            {
                var id = Guid.NewGuid();
                mapAddress.Id = id.ToString();

                _context.Mapaddress.Add(mapAddress);
                _context.SaveChanges();

                message.Success = true;
                message.Reason = "Location Sent to Database";
                message.Data = mapAddress;

                return message;
            }
            message.Success = false;
            message.Reason = "Error Sending Location to Database";
            message.Data = mapAddress;

            return message;
        }
    }
}

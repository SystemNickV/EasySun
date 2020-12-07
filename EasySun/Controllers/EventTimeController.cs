using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasySun.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasySun.Models;
using SunriseSunsetClient;

namespace EasySun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTimeController : ControllerBase
    {
        private readonly SunDbContext _dbContext;

        public EventTimeController(SunDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/EventTime
        [HttpGet]
        public async Task<ActionResult<EventTime>> GetEventTime([FromQuery]string city, [FromQuery]DateTime date = default)
        {
            var sun = await _dbContext.EventTimes
                .Where(s => s.City.Name == city && s.RequestDate == date)
                .FirstOrDefaultAsync();

            if (sun != null)
                return sun;

            var tempCity = await _dbContext.Cities
                .Where(c => c.Name == city)
                .FirstOrDefaultAsync();

            var client = new SunClient();
            var fullSun = await client.GetSunTimingsAsync(tempCity.Latitude, tempCity.Longitude, date);

            sun = (await _dbContext.EventTimes.AddAsync(new EventTime
            {
                RequestDate = date != default ? date : DateTime.UtcNow,
                Sunrise = fullSun.SunriseAtUtc,
                Sunset = fullSun.SunsetAtUtc,
                CityFK = tempCity.Id
            })).Entity;

            await _dbContext.SaveChangesAsync();

            return sun;
        }
    }
}

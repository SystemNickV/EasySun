using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasySun.Database;
using EasySun.Models;
using EasySun.Service;
using Microsoft.Extensions.Logging;

namespace EasySun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly SunDbContext _dbContext;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(SunDbContext dbContext, ILogger<CitiesController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            _logger.LogInformation(
                SunLogEvents.GetItems, 
                SunLogCrudMessages.GetAll,
                typeof(City),
                DateTime.UtcNow.ToLongTimeString());

            return await _dbContext.Cities.ToListAsync();
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(long id)
        {
            _logger.LogInformation(
                SunLogEvents.GetItem,
                SunLogCrudMessages.GetById,
                id,
                DateTime.UtcNow.ToLongTimeString());

            var city = await _dbContext.Cities.FindAsync(id);

            if (city == null)
            {
                _logger.LogWarning(
                    SunLogEvents.GetItemNotFound,
                    SunLogCrudMessages.GetByIdNotFound,
                    id,
                    DateTime.UtcNow.ToLongTimeString());
                return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(long id, City city)
        {
            _logger.LogInformation(
                SunLogEvents.UpdateItem,
                SunLogCrudMessages.UpdateById,
                id,
                DateTime.UtcNow.ToLongTimeString());

            if (id != city.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(city).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
                {
                    _logger.LogWarning(
                        SunLogEvents.UpdateItemNotFound,
                        SunLogCrudMessages.UpdateByIdNotFound,
                        id,
                        DateTime.UtcNow.ToLongTimeString());
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cities
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            _logger.LogInformation(
                SunLogEvents.InsertItem,
                SunLogCrudMessages.Insert,
                DateTime.UtcNow.ToLongTimeString());

            // ReSharper disable once MethodHasAsyncOverload
            _dbContext.Cities.Add(city);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCity), new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(long id)
        {
            _logger.LogInformation(
                SunLogEvents.DeleteItem,
                SunLogCrudMessages.DeleteById,
                id,
                DateTime.UtcNow.ToLongTimeString());

            var city = await _dbContext.Cities.FindAsync(id);
            if (city == null)
            {
                _logger.LogWarning(
                    SunLogEvents.DeleteItemNotFound,
                    SunLogCrudMessages.DeleteByIdNotFound,
                    id,
                    DateTime.UtcNow.ToLongTimeString());
                return NotFound();
            }

            _dbContext.Cities.Remove(city);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(long id)
        {
            return _dbContext.Cities.Any(e => e.Id == id);
        }
    }
}

using IndoorTracker.API.Models;
using IndoorTracker.Domain.Models.SensorData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndoorTracker.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SensorDataController : ControllerBase
    {
        private readonly ISensorDataRepository _repository;

        public SensorDataController(ISensorDataRepository repository)
        {
            _repository = repository;
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SensorDataModel model)
        {

            List<Wifi> wifis = new List<Wifi>();

            foreach (var item in model.s.wifi)
                wifis.Add(new Wifi { MacAddress = item.Key, RSSI = item.Value });

            var sensorData = new SensorData()
            {
                Device = model.d,
                Family = model.f,
                GPS = new Gps()
                {
                    Altitude = model.gps["alt"],
                    Latitude = model.gps["lat"],
                    Longitude = model.gps["lon"]
                },
                Wifis = wifis,
                Date = UnixTimeStampToDateTime(model.t)
            };

            _repository.Add(sensorData);

            await _repository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = sensorData.Id }, null);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var sensorData = await _repository.GetAsync(id);

            if (sensorData != null)
            {
                return Ok(sensorData);
            }

            return NotFound();
        }

        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

    }
}
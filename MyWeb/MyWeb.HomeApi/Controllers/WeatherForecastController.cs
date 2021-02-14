using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWeb.HomeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.HomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }



        //일반적으로 생각했을때 CRUD를 생각하는데 Rest 기준으로 CRUD를 생각해보면 
        // : HttpPost (Insert)
        // : HttpGet (Read)
        // : HttpPut (Update)
        // : HttpDelete (Delete)
        //Read
        [HttpGet]
        public IEnumerable<WeatherForecastModel> Get(int num)
        {
            var rng = new Random();
            return Enumerable.Range(1, num).Select(index => new WeatherForecastModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        //Insert
        [HttpPost]
        public WeatherForecastModel Post([FromForm] int addDay)
        {
            return new WeatherForecastModel() { Date = DateTime.Now.AddDays(addDay) };
        }

        //Update
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }
        //Delete
        [HttpDelete]
        public IActionResult Delete(int key)
        {
            //Key 처리를 했다.
            //return Ok();

            //실패를 했다.
            return BadRequest(new { message = "잘못된 요청입니다."});
        }
    }
}

using GenericRepository.GenericRepository;
using GenericRepository.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepository<WeatherForecast> _repository;

        public WeatherForecastController(IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Set([FromBody] WeatherForecast request)
        {
            _repository.Add(request);
            _repository.Save();

            return Ok();
        }
    }
}
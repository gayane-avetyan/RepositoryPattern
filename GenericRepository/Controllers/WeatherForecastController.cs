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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _repository.Get(id);

            return Ok(entity);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBySummary(string summary)
        {
            var entity = await _repository.Find(m => m.Summary == summary);

            return Ok(entity);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var entity = await _repository.GetAll();

            return Ok(entity);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBySummary(string summary)
        {
            var entity = await _repository.GetWhere(m => m.Summary == summary);

            return Ok(entity);
        }

        [HttpPost("[action]")]
        public IActionResult Save([FromBody] WeatherForecast request)
        {
            _repository.Add(request);
            _repository.Save();

            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult SaveAll([FromBody] WeatherForecast[] request)
        {
            _repository.AddRange(request);
            _repository.Save();

            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult Update([FromBody] WeatherForecast request)
        {
            _repository.Update(request);
            _repository.Save();

            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult UpdateAll([FromBody] WeatherForecast[] request)
        {
            _repository.UpdateRange(request);
            _repository.Save();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var entity = _repository.Find(e => e.Id == id).Result;

            _repository.Delete(entity);
            _repository.Save();

            return Ok();
        }

        [HttpDelete("[action]")]
        public IActionResult RemoveAll(string summary)
        {
            var entity = _repository.GetWhere(m => m.Summary == summary).Result;

            _repository.DeleteRange(entity);
            _repository.Save();

            return Ok();
        }
    }
}

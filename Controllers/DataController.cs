using ClientApp.Data;
using ClientApp.Interface;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IApiService _apiService;
        private readonly DataContext _Context;
        public DataController(IApiService apiService, DataContext context)
        {
            _apiService = apiService;
            _Context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetDataFromApiAndStoreInDatabase()
        {
            var dataFromApi = await _apiService.GetDataFromApi();

            if (dataFromApi != null)
            {
                _Context.Stocks.AddRange(dataFromApi);
                await _Context.SaveChangesAsync();
                RecurringJob.AddOrUpdate("my-recurring-job", () => _apiService.GetDataFromApi(), Cron.HourInterval(6));
                return Ok("Data stored in the database successfully.");
            }

            return BadRequest("Failed to retrieve data from the API.");
        }
    }
}

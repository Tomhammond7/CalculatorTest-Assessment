using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SimpleCalculatorApp.Models;
using System.Diagnostics;

namespace SimpleCalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CalculatorController(ILogger<CalculatorController> logger, HttpClient httpClient, IConfiguration configuration)
        {
            _logger = logger;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Calculate(int start, int amount)
        {
            string apiUrl = _configuration["CalculatorApiUrl"];

            string requestUrl = $"{apiUrl}?start={start}&amount={amount}";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode) 
            {
                string result = await response.Content.ReadAsStringAsync();
                if (int.TryParse(result, out int value))
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Invalid response format.");
                }
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] int start, [FromForm] int amount)
        {
            string apiUrl = _configuration["CalculatorApiUrl"];
            string requestUrl = $"{apiUrl}/add?start={start}&amount={amount}";

            var response = await _httpClient.PostAsync(requestUrl, null);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                if (int.TryParse(result, out int value))
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Invalid response format.");
                }
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Subtract([FromForm] int start, [FromForm] int amount)
        {
            string apiUrl = _configuration["CalculatorApiUrl"];
            string requestUrl = $"{apiUrl}/subtract?start={start}&amount={amount}";

            var response = await _httpClient.PostAsync(requestUrl, null);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                if (int.TryParse(result, out int value))
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Invalid response format.");
                }
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
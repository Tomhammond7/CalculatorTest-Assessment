using CalculatorTest;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorTestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private SimpleCalculator calculator;

        public CalculatorController()
        {
            calculator = new SimpleCalculator();
        }

        [HttpPost("add")]
        public IActionResult Add(int start, int amount)
        {
            int result = calculator.Add(start, amount);
            return Ok(result);
        }

        [HttpPost("subtract")]
        public IActionResult Subtract(int start, int amount)
        {
            int result = calculator.Subtract(start, amount);
            return Ok(result);
        }
    }
}
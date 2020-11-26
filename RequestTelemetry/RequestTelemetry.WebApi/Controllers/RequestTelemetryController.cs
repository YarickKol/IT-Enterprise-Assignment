using Microsoft.AspNetCore.Mvc;
using RequestTelemetry.Domain.Services;
using RequestTelemetry.WebApi.Model;
using System.Threading.Tasks;

namespace RequestTelemetry.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTelemetryController : ControllerBase {
        private readonly RateService _service;
        public RequestTelemetryController(RateService service) {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> StartMeasurement([FromBody] InputParams inputParams) {
            if (inputParams.Frequency == 0) {
                await _service.MeasureRequestAsync(inputParams.Url);
            } else {
                await _service.StartMeasurementLoop(inputParams.Url, inputParams.Frequency);
            }
            return Ok();
        }
    }
}

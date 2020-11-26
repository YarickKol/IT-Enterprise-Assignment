using Microsoft.AspNetCore.Mvc;
using RequestTelemetry.Domain.DTO;
using RequestTelemetry.Domain.Services;
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
        public async Task<IActionResult> StartMeasurement(string url/*, int milliseconds*/) {
            _service.SimpleCall(url);
            return Ok();
        }
    }
}

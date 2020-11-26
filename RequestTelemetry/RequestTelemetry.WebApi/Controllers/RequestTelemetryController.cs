using Hangfire;
using Microsoft.AspNetCore.Mvc;
using RequestTelemetry.Domain.DTO;
using RequestTelemetry.Domain.Services;
using RequestTelemetry.WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestTelemetry.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTelemetryController : ControllerBase {
        private readonly RateService _service;
        private readonly FetchService _fetchService;
        public RequestTelemetryController(RateService service, FetchService fetchService) {
            _service = service;
            _fetchService = fetchService;
        }

        [HttpPost]
        public async Task<IActionResult> StartMeasurement([FromBody] InputParams inputParams) {
            if (inputParams.Frequency == 0) {
                await _service.MeasureRequestAsync(inputParams.Url);
            } else {
                BackgroundJob.Enqueue(() => _service.StartMeasurementLoop(inputParams.Url, inputParams.Frequency));
            }
            return Ok();
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IList<RequestDTO>>> FetchResults() {
            return Ok(await _fetchService.FetchRequests());
        }

        [HttpGet("getby")]
        public async Task<ActionResult<IList<RequestDTO>>> FetchResults(string url) {
            return Ok(await _fetchService.FetchRequests(url));
        }
    }
}

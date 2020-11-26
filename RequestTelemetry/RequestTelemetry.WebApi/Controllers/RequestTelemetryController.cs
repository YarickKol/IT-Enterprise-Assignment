using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequestTelemetry.Data;
using RequestTelemetry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

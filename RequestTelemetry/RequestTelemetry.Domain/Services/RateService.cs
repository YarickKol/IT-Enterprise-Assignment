using AutoMapper;
using RequestTelemetry.Data;
using RequestTelemetry.Domain.DTO;
using System.Threading.Tasks;

namespace RequestTelemetry.Domain.Services {
    public class RateService {
        private readonly IMapper _mapper;
        private readonly TelemetryContext _context;
        private readonly TelemetryService _telemetryService;

        public RateService(TelemetryContext context, IWebRequester webRequester, IMapper mapper) {
            _context = context;
            _mapper = mapper;
            _telemetryService = new TelemetryService(webRequester);
        }

        public async Task StartMeasurementLoop(string url, int frequency) {
            while (true) {
                await MeasureRequestAsync(url);
                await Task.Delay(frequency);
            }
        }

        public async Task<RequestDTO> MeasureRequestAsync(string url) {
            RequestDTO requestDTO = await _telemetryService.MeasureRequestAsync(url);
            Request request = _mapper.Map<Request>(requestDTO);

            _context.Add(request);
            _context.SaveChanges();

            return requestDTO;
        }
    }
}

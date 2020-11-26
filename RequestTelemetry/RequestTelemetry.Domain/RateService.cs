using AutoMapper;
using RequestTelemetry.Data;
using System.Threading.Tasks;

namespace RequestTelemetry.Domain {
    public class RateService {
        private readonly IMapper _mapper;
        private readonly TelemetryContext _context;
        private readonly TelemetryService _telemetryService;

        public RateService(TelemetryContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
            _telemetryService = new TelemetryService(new WebRequester());
        }

        public async Task SimpleCall(string url) {
            RequestDTO requestDTO = await _telemetryService.MeasureRequestAsync(url);
            Request request = _mapper.Map<Request>(requestDTO);

            _context.Add(request);
            _context.SaveChanges();
        }
    }
}

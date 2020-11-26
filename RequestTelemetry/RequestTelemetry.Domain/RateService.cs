using AutoMapper;
using RequestTelemetry.Data;

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

        public void SimpleCall(string url) {
            RequestDTO requestDTO = _telemetryService.MeasureRequest(url);
            Request request = _mapper.Map<Request>(requestDTO);

            _context.Add(request);
            _context.SaveChanges();
        }
    }
}

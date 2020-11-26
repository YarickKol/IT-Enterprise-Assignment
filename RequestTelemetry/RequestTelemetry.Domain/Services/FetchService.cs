using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RequestTelemetry.Data;
using RequestTelemetry.Domain.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestTelemetry.Domain.Services {
    public class FetchService {
        private readonly IMapper _mapper;
        private readonly TelemetryContext _context;

        public FetchService(TelemetryContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<RequestDTO>> FetchRequests() {
            var requests = await _context.Requests.ToListAsync();
            return _mapper.Map<IList<RequestDTO>>(requests);
        }

        public async Task<IList<RequestDTO>> FetchRequests(string url) {
            var requests = await _context.Requests.Where(x => x.Url == url).ToListAsync();
            return _mapper.Map<IList<RequestDTO>>(requests);
        }
    }
}

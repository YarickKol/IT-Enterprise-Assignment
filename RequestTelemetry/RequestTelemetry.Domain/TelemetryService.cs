using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RequestTelemetry.Domain {
    public class TelemetryService {
        private readonly IWebRequester _webRequester;

        public TelemetryService(IWebRequester webRequester) {
            _webRequester = webRequester;
        }

        public async Task<RequestDTO> MeasureRequestAsync(string url) {
            var stopwatch = new Stopwatch();
            var request = new RequestDTO { Url = url };
            var sentAt = DateTime.Now;
            _webRequester.CreateInstance(url);

            stopwatch.Start();
            var webResponse = await _webRequester.GetResponseAsync();
            stopwatch.Stop();

            request.SentAt = sentAt;
            request.ResponseTime = new TimeSpan(stopwatch.ElapsedTicks);
            request.StatusCode = webResponse.StatusCode;
            return request;
        }
    }
}

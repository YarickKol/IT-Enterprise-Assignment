using System;
using System.Diagnostics;

namespace RequestTelemetry.Domain {
    public class TelemetryService {
        private readonly IWebRequester _webRequester;

        public TelemetryService(IWebRequester webRequester) {
            _webRequester = webRequester;
        }

        public RequestDTO MeasureRequest(string url) {
            var stopwatch = new Stopwatch();
            var request = new RequestDTO { Url = url };
            var sentAt = DateTime.Now;
            _webRequester.CreateInstance(url);

            stopwatch.Start();
            var webResponse = _webRequester.GetResponse();
            stopwatch.Stop();

            request.SentAt = sentAt;
            request.Response = new TimeSpan(stopwatch.ElapsedTicks);
            request.StatusCode = webResponse.StatusCode;
            return request;
        }
    }
}

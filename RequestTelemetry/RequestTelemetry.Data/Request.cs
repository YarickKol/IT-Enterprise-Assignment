using System;

namespace RequestTelemetry.Data {
    public class Request {
        public int Id { get; set; }
        public string Url { get; set; }
        public string StatusCode { get; set; }
        public DateTime SentAt { get; set; }
        public TimeSpan ResponseTime { get; set; }
    }
}

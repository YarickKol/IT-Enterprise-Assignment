using System;
using System.Net;

namespace RequestTelemetry.Domain {
    public class RequestDTO {
        public int Id { get; set; }
        public string Url { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public DateTime SentAt { get; set; }
        public TimeSpan Response { get; set; }
    }
}

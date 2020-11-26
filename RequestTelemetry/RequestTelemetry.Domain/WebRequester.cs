using System.Net;

namespace RequestTelemetry.Domain {
    public class WebRequester : IWebRequester {
        private WebRequest _webRequest;

        public void CreateInstance(string url) {
            _webRequest = WebRequest.Create(url);
            _webRequest.Timeout = 5000;
        }

        public void CreateInstance(string url, int timeout) {
            _webRequest = WebRequest.Create(url);
            _webRequest.Timeout = timeout;
        }

        public HttpWebResponse GetResponse() {
            return _webRequest.GetResponse() as HttpWebResponse;
        }
    }
}

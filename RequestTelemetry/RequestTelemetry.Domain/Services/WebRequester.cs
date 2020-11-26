using System.Net;
using System.Threading.Tasks;

namespace RequestTelemetry.Domain.Services {
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

        public async Task<HttpWebResponse> GetResponseAsync() {
            return await _webRequest.GetResponseAsync() as HttpWebResponse;
        }
    }
}

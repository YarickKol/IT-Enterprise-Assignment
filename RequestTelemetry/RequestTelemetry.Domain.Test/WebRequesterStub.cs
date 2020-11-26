using Moq;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RequestTelemetry.Domain.Test {
    public class WebRequesterStub : IWebRequester {
        private readonly int _millisecondsTimeout;

        public WebRequesterStub(int millisecondsTimeout) {
            _millisecondsTimeout = millisecondsTimeout;
        }

        public void CreateInstance(string url) {

        }

        public void CreateInstance(string url, int timeout) {

        }

        public async Task<HttpWebResponse> GetResponseAsync() {
            var httpWebResponse = new Mock<HttpWebResponse>();
            httpWebResponse.Setup(x => x.StatusCode).Returns(HttpStatusCode.OK);
            await Task.Delay(_millisecondsTimeout);
            return httpWebResponse.Object;
        }
    }
}

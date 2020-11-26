using Moq;
using System;
using System.Net;
using System.Threading;

namespace RequestTelemetry.Domain.Test {
    public class WebRequesterStub : IWebRequester {
        private readonly int _millisecondsTimeout;

        public WebRequesterStub(int millisecondsTimeout) {
            _millisecondsTimeout = millisecondsTimeout;
        }

        public void CreateInstance(string url) {
            throw new NotImplementedException();
        }

        public void CreateInstance(string url, int timeout) {
            throw new NotImplementedException();
        }

        public HttpWebResponse GetResponse() {
            var httpWebResponse = new Mock<HttpWebResponse>();
            httpWebResponse.Setup(x => x.StatusCode).Returns(HttpStatusCode.OK);
            Thread.Sleep(_millisecondsTimeout);
            return httpWebResponse.Object;
        }
    }
}

using System.Net;

namespace RequestTelemetry.Domain {
    public interface IWebRequester {
        void CreateInstance(string url);
        void CreateInstance(string url, int timeout);
        HttpWebResponse GetResponse();
    }
}

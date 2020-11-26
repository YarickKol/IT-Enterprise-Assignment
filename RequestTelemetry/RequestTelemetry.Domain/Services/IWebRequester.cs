using System.Net;
using System.Threading.Tasks;

namespace RequestTelemetry.Domain.Services {
    public interface IWebRequester {
        void CreateInstance(string url);
        void CreateInstance(string url, int timeout);
        Task<HttpWebResponse> GetResponseAsync();
    }
}

using NUnit.Framework;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace RequestTelemetry.Domain.Test {
    [TestFixture]
    public class TelemetryServiceTest {
        [Test]
        public async Task Execute_MeasureRequest_Should_ReturnOkAfter2Seconds() {
            var service = new TelemetryService(new WebRequesterStub(2000));

            RequestDTO request = await service.MeasureRequestAsync("Dummy");

            request.Url.ShouldBe("Dummy");
            request.Response.ShouldBeInRange(new TimeSpan(0, 0, 2), new TimeSpan(0, 0, 3));
            request.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }
    }
}
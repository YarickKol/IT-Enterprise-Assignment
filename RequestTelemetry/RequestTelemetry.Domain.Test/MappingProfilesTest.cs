using AutoMapper;
using NUnit.Framework;
using RequestTelemetry.Data;
using RequestTelemetry.Domain.AutoMapper;
using RequestTelemetry.Domain.DTO;
using Shouldly;
using System;
using System.Net;

namespace RequestTelemetry.Domain.Test {
    [TestFixture]
    public class MappingProfilesTest {
        private IMapper _mapper;

        [SetUp]
        public void Setup() {
            _mapper = new MapperConfiguration(AutoMapperDomainConfiguration.Configuration()).CreateMapper();
        }

        [Test]
        public void Execute_Mapping_ShouldConvertDTOToEntity() {
            var requestDTO = new RequestDTO {
                Id = 1,
                Url = "Dummy",
                ResponseTime = new TimeSpan(1, 2, 3),
                SentAt = new DateTime(1, 2, 3, 4, 5, 6),
                StatusCode = HttpStatusCode.OK
            };
            var extected = new Request {
                Id = 1,
                Url = "Dummy",
                ResponseTime = new TimeSpan(1, 2, 3),
                SentAt = new DateTime(1, 2, 3, 4, 5, 6),
                StatusCode = "OK"
            };

            Request actulal = _mapper.Map<Request>(requestDTO);

            extected.Id.ShouldBe(actulal.Id);
            extected.Url.ShouldBe(actulal.Url);
            extected.ResponseTime.ShouldBe(actulal.ResponseTime);
            extected.SentAt.ShouldBe(actulal.SentAt);
            extected.StatusCode.ShouldBe(actulal.StatusCode);
        }

        [Test]
        public void Execute_Mapping_ShouldConvertEntityToDTO() {
            var request = new Request {
                Id = 1,
                Url = "Dummy",
                ResponseTime = new TimeSpan(1, 2, 3),
                SentAt = new DateTime(1, 2, 3, 4, 5, 6),
                StatusCode = "OK"
            };
            var extected = new RequestDTO {
                Id = 1,
                Url = "Dummy",
                ResponseTime = new TimeSpan(1, 2, 3),
                SentAt = new DateTime(1, 2, 3, 4, 5, 6),
                StatusCode = HttpStatusCode.OK
            };

            RequestDTO actulal = _mapper.Map<RequestDTO>(request);

            extected.Id.ShouldBe(actulal.Id);
            extected.Url.ShouldBe(actulal.Url);
            extected.ResponseTime.ShouldBe(actulal.ResponseTime);
            extected.SentAt.ShouldBe(actulal.SentAt);
            extected.StatusCode.ShouldBe(actulal.StatusCode);
        }
    }
}

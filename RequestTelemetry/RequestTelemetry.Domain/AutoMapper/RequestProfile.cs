using AutoMapper;
using RequestTelemetry.Data;
using RequestTelemetry.Domain.DTO;
using System;
using System.Net;

namespace RequestTelemetry.Domain.AutoMapper {
    public class RequestProfile : Profile {
        public RequestProfile() {
            CreateMap<RequestDTO, Request>().ForMember(
                dest => dest.StatusCode,
                act => act.MapFrom(
                    scr => scr.StatusCode.ToString())
            );

            CreateMap<Request, RequestDTO>().ForMember(
                dest => dest.StatusCode,
                act => act.MapFrom(
                    scr => Enum.Parse(typeof(HttpStatusCode), scr.StatusCode, true)));
        }
    }
}

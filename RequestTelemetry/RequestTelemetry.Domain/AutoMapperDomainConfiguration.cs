using AutoMapper;
using System;

namespace RequestTelemetry.Domain {
    public class AutoMapperDomainConfiguration {
        public static Action<IMapperConfigurationExpression> Configuration() {
            return cfg => {
                cfg.AddProfile(new RequestProfile());
            };
        }
    }
}

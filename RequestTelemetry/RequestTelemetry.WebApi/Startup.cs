using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RequestTelemetry.Data;
using RequestTelemetry.Domain.AutoMapper;
using RequestTelemetry.Domain.Services;
using System.Reflection;

namespace RequestTelemetry.WebApi {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<TelemetryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RequestTelemetryDbConnection")));
            services.AddScoped<RateService>();
            services.AddScoped<IWebRequester, WebRequester>();
            services.AddAutoMapper(AutoMapperDomainConfiguration.Configuration(), Assembly.GetExecutingAssembly());
            services.AddHangfire(options => options.UseSqlServerStorage(Configuration.GetConnectionString("RequestTelemetryDbConnection")));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseHangfireServer();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}

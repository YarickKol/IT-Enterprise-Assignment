using Microsoft.EntityFrameworkCore;

namespace RequestTelemetry.Data {
    public class TelemetryContext : DbContext {
        public DbSet<Request> Requests { get; set; }

        public TelemetryContext(DbContextOptions<TelemetryContext> options) : base (options) { }
    }
}

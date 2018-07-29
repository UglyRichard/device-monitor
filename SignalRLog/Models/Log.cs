namespace SignalRLog.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LogContext : DbContext
    {
        public LogContext()
            : base("name=Monitor")
        {
//            Database.SetInitializer<LogContext>(new CreateDatabaseIfNotExists<LogContext>());
        }

        public DbSet<Log> Logs { get; set; }
    }

    public class Log
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
/*
    public class LogDBInitializer : CreateDatabaseIfNotExists<LogContext>
    {
        protected override void Seed(LogContext context)
        {
            base.Seed(context);
        }
    }
*/
}
using DAL.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly string _dbPath;

        public LogsController(IConfiguration config)
        {
            var connectionString =
                config.GetConnectionString("LogDatabase")
                ?? throw new Exception("DbString not found in appsettings.");

            _dbPath = Environment.ExpandEnvironmentVariables(connectionString);
        }

        [HttpGet]
        public IActionResult GetLogs()
        {
            using var db = new LiteDatabase(_dbPath);
            var logs = db.GetCollection<LogEntry>("logs")
                .Query()
                .OrderByDescending(l => l.Timestamp)
                .Limit(100)
                .ToList();

            return Ok(logs);
        }
    }
}

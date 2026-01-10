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
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var connectionString =
                config.GetConnectionString("LogDatabase")
                ?? throw new Exception("LogDatabase name not found in appsettings.");
            var path = Path.Combine(Environment.GetFolderPath(folder), connectionString);
            _dbPath = path;
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

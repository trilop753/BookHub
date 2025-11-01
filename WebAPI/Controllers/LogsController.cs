using DAL.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly string _dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "logs_litedb.db"
        );

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

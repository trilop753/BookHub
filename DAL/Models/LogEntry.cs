namespace DAL.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string Method { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public double DurationMs { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        
        public string Source { get; set; }
    }
}
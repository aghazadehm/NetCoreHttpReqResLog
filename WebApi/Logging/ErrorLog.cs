using System.ComponentModel.DataAnnotations;

namespace WebApi.Logging
{
    public class ErrorLog
    {
        [Key]
        public long ErrorLogId { get; internal set; }
        public int StatusCode { get; internal set; }
        public string? Exception { get; internal set; }
        public string? ExceptionMessage { get; internal set; }
        public string? AppName { get; internal set; }
        public string? UserName { get; internal set; }
        public DateTime RequestedOn { get; internal set; }
        public string? RequestPath { get; internal set; }
        public string? RequestMethod { get; internal set; }
        public string? RequestQueryString { get; internal set; }
        public string? Payload { get; internal set; }
    }
}
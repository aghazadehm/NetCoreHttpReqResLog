using System.ComponentModel.DataAnnotations;

namespace WebApi.Logging
{
    public class ReqResLog
    {
        [Key]
        public long LogId { get; internal set; }
        public string? UserName { get; internal set; }
        public string? Path { get; internal set; }
        public string? QueryString { get; internal set; }
        public string? Method { get; internal set; }
        public string? Payload { get; internal set; }
        public string? Response { get; internal set; }
        public string? ResponseCode { get; internal set; }
        public DateTime RequestedOn { get; internal set; }
        public DateTime RespondedOn { get; internal set; }
        public bool IsSuccessStatusCode { get; internal set; }
    }
}

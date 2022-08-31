namespace WebApi.ErrorHandling.Exceptions
{
    public class GetRequestException : Exception
    {
        public GetRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
namespace WebApi.ErrorHandling.Exceptions
{
    public class PostRequestException : Exception
    {
        public PostRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
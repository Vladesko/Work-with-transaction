namespace Application.Common.Exceptions
{
    public class CustomValidationException(string message, int code) : Exception(message)
    {
        public int code = code;
    }
}

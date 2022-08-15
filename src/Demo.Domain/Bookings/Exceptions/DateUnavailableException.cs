using System.Runtime.Serialization;

namespace Demo.Domain.Bookings.Exceptions;

[Serializable]
public class DateUnavailableException : Exception
{
    public DateUnavailableException()
    { }

    public DateUnavailableException(string? message) : base(message)
    { }

    public DateUnavailableException(string? message, Exception? innerException) : base(message, innerException)
    { }

    protected DateUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}

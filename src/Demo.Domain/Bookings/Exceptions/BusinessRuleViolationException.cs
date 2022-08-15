using System.Runtime.Serialization;

namespace Demo.Domain.Bookings.Exceptions;

[Serializable]
public class BusinessRuleViolationException : Exception
{
    public BusinessRuleViolationException()
    { }

    public BusinessRuleViolationException(string? message) : base(message)
    { }

    public BusinessRuleViolationException(string? message, Exception? innerException) : base(message, innerException)
    { }

    protected BusinessRuleViolationException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}

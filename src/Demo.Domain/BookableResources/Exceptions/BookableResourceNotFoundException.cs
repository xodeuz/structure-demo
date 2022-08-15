using System.Runtime.Serialization;

namespace Demo.Domain.BookableResources.Exceptions;

/// <summary>
///     Custom domain exception
/// </summary>
[Serializable]
public class BookableResourceNotFoundException : Exception
{
    public BookableResourceNotFoundException()
    { }

    public BookableResourceNotFoundException(string? message) : base(message)
    { }

    public BookableResourceNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    { }

    protected BookableResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}

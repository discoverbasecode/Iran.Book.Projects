namespace Framework.Domain.Exceptions;

public class BaseDomainException : Exception
{
    protected BaseDomainException() { }

    protected BaseDomainException(string message) : base(message ?? string.Empty) { }

    protected BaseDomainException(string message, Exception? innerException) : base(message ?? string.Empty, innerException) { }

}

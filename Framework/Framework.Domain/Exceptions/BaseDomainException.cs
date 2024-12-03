namespace Framework.Domain.Exceptions;

public class BaseDomainException : Exception
{
    public BaseDomainException() { }

    public BaseDomainException(string message) : base(message ?? string.Empty) { }

    public BaseDomainException(string message, Exception? innerException) : base(message ?? string.Empty, innerException) { }

}

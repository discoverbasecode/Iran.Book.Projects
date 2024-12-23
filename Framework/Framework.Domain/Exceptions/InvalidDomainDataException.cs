namespace Framework.Domain.Exceptions;

public class InvalidDomainDataException : BaseDomainException
{
    public InvalidDomainDataException() { }

    public InvalidDomainDataException(string message) : base(message ?? string.Empty) { }

    public InvalidDomainDataException(string message, System.Exception? innerException) : base(message ?? string.Empty, innerException) { }
}

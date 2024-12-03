namespace Framework.Domain.Exceptions;

public class NullOrEmptyDomainDataException : BaseDomainException
{
    public NullOrEmptyDomainDataException() { }

    public NullOrEmptyDomainDataException(string message) : base(message ?? string.Empty) { }

    public static void CheckString(string? value, string nameOfField)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new NullOrEmptyDomainDataException($"{nameOfField} is null or empty");
    }
}
namespace Framework.Domain.ValueObjects;

public class Address(string province, string city, string postalAddress) : ValueObject
{
    public string Province { get; private set; } = province ?? string.Empty;
    public string City { get; private set; } = city ?? string.Empty;
    public string PostalAddress { get; private set; } = postalAddress ?? string.Empty;

    public Address Edit(string province, string city, string postalAddress)
    {
        return new Address(province ?? string.Empty, city ?? string.Empty, postalAddress ?? string.Empty);
    }

    public static Address EmptyAddress()
    {
        return new Address(string.Empty, string.Empty, string.Empty);
    }

}
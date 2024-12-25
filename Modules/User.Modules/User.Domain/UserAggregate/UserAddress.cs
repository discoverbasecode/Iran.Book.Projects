using Framework.Application.MessegeUtils;
using Framework.Domain.Entities;
using Framework.Domain.Exceptions;
using Framework.Domain.Utils;

namespace User.Domain.UserAggregate;

public class UserAddress : BaseEntity
{
    public Guid UserId { get; private set; }
    public string Shire { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public string PhoneNumber { get; private set; }
    public string NationalCode { get; private set; }
    public string FullName { get; private set; }

    #region ----------------------------------------------------- User Address Method

    public UserAddress()
    {
    }

    private UserAddress(string shire, string city, string postalCode, string postalAddress, string phoneNumber,
        string nationalCode, string fullName)
    {
        Guard(shire, city, postalCode, postalAddress, phoneNumber, nationalCode, fullName);
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        NationalCode = nationalCode;
        FullName = fullName;
    }

    public static UserAddress Create(string shire, string city, string postalCode, string postalAddress,
        string phoneNumber, string nationalCode, string fullName)
    {
        return new UserAddress(shire, city, postalAddress, postalAddress, phoneNumber, nationalCode, fullName);
    }

    public void Edit(string shire, string city, string postalCode, string postalAddress, string phoneNumber,
        string nationalCode, string fullName)
    {
        Guard(shire, city, postalCode, postalAddress, phoneNumber, nationalCode, fullName);

        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        NationalCode = nationalCode;
        FullName = fullName;
        UpdateAudit(Id);
    }

    #endregion

    #region ----------------------------------------------------- Guard Method

    private void Guard(string shire, string city, string postalCode, string postalAddress, string phoneNumber,
        string nationalCode, string fullName)
    {
        NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
        NullOrEmptyDomainDataException.CheckString(city, nameof(city));
        NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
        NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
        NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
        NullOrEmptyDomainDataException.CheckString(fullName, nameof(fullName));
        if (IranianNationalIdChecker.IsValid(nationalCode) == false)
            throw new InvalidDomainDataException(TemplateMessages.invalidNationalCode);
    }

    public void ActiveAddress() => IsActive = true;
    public void DeActiveAddress() => IsActive = false;

    #endregion
}
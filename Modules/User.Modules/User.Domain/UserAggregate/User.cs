using Framework.Application.MessegeUtils;
using Framework.Domain;
using Framework.Domain.Aggregates;
using Framework.Domain.Exceptions;
using User.Domain.UserAggregate.Enums;
using User.Domain.UserAggregate.Services;

namespace User.Domain.UserAggregate;

public class User : AggregateRoot
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Password { get; private set; }
    public Gender Gender { get; private set; }

    public List<UserAddress> UserAddresses { get; private set; }
    public List<Wallet> Wallets { get; private set; }
    public List<UserRole> UserRoles { get; private set; }


    #region ------------------------------------------------------- Methods User

    public User()
    {
    }

    private User(string fullName, string email, string phoneNumber, string password, Gender gender,
        IDomainUserService domainUserService)
    {
        Guard(phoneNumber, email, domainUserService);

        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
        Gender = gender;
    }

    public static User Create(string fullName, string email, string phoneNumber, string password, Gender gender,
        IDomainUserService domainUserService)
    {
        return new User(fullName, email, phoneNumber, password, gender, domainUserService);
    }

    public void Edit(string fullName, string email, string phoneNumber, string password, Gender gender,
        IDomainUserService domainUserService)
    {
        Guard(phoneNumber, email, domainUserService);

        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
        Gender = gender;
        UpdateAudit(Id);
    }

    #endregion

    #region ------------------------------------------------------- Methods Address

    public void AddAddress(UserAddress userAddress)
    {
        userAddress.Id = Id;
        UserAddresses.Add(userAddress);
    }

    public void EditAddress(UserAddress userAddress)
    {
        var firstAddress = UserAddresses.FirstOrDefault(a => a.Id == userAddress.Id);
        if (firstAddress is null) throw new NullOrEmptyDomainDataException("Address not found");
        UserAddresses.Remove(firstAddress);
        UserAddresses.Add(userAddress);
    }

    public void RemoveAddress(Guid id)
    {
        var firstAddress = UserAddresses.FirstOrDefault(a => a.Id == id);
        if (firstAddress is null) throw new NullOrEmptyDomainDataException("Address not found");
        UserAddresses.Remove(firstAddress);
    }

    #endregion

    #region ------------------------------------------------------- Methods Wallet

    public void AddWallet(Wallet wallet)
    {
        wallet.Id = Id;
        Wallets.Add(wallet);
    }

    #endregion

    #region ------------------------------------------------------- Methods Role

    public void AddRole(UserRole userRole)
    {
        userRole.Id = Id;
        UserRoles.Add(userRole);
    }

    #endregion

    #region ------------------------------------------------------- Gurds

    private void Guard(string phoneNumber, string email, IDomainUserService domainUserService)
    {
        NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
        NullOrEmptyDomainDataException.CheckString(email, nameof(email));
        if (phoneNumber.Length != 11)
            throw new InvalidDomainDataException(TemplateMessages.invalidPhoneNumber(phoneNumber));

        if (email.IsValidEmail() == false) throw new InvalidDomainDataException(TemplateMessages.invalidEmail(email));

        if (phoneNumber != PhoneNumber)
            if (domainUserService.IsPhoneNumberExists(phoneNumber))
                throw new InvalidDomainDataException(TemplateMessages.invalidPhoneNumber(phoneNumber));

        if (email == Email) return;
        if (domainUserService.IsEmailExists(email))
            throw new InvalidDomainDataException(TemplateMessages.invalidEmail(email));
    }

    #endregion

    #region ------------------------------------------------------- Methods Role 
    public void SetRole(List<UserRole> roles)
    {
        roles.ForEach(r => r.UserId = Id);
        UserRoles.Clear();
        UserRoles.AddRange(roles);
    }
    #endregion
}
namespace User.Domain.UserAggregate.Services;

public interface IDomainUserService
{
    bool IsEmailExists(string email);
    bool IsPhoneNumberExists(string phoneNumber);
}
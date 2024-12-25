using Framework.Domain.Aggregates;
using Framework.Domain.Exceptions;
using User.Domain.UserAggregate.Enums;

namespace User.Domain.UserAggregate;

public class Wallet : AggregateRoot
{
    public Guid UserId { get; private set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public DateTime? FinallyDate { get; private set; }
    public WalletType WalletType { get; private set; }

    public Wallet() { }
    private Wallet(int price, string description, bool isFinally, DateTime? finallyDate, WalletType walletType)
    {
        if (price < 500)
            throw new InvalidDomainDataException();
        Price = price;
        Description = description;
        IsFinally = isFinally;
        FinallyDate = finallyDate;
        WalletType = walletType;
    }

    public void Finally(string refCode)
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
        Description += $"کد پیگیر  - {refCode}";
    }

    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
    }

    public static Wallet Create(int price, string description, bool isFinally, DateTime? finallyDate, WalletType walletType)
    {
        return new Wallet(price, description, isFinally, finallyDate, walletType);
    }

    public void Edit(int price, string description, bool isFinally, DateTime? finallyDate, WalletType walletType)
    {
        Price = price;
        Description = description;
        IsFinally = isFinally;
        FinallyDate = finallyDate;
        WalletType = walletType;
        UpdateAudit(Id);
    }

}
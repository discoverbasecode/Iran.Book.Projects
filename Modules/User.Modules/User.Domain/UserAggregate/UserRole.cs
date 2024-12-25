using Framework.Domain.Aggregates;
using Framework.Domain.Entities;

namespace User.Domain.UserAggregate;

public class UserRole : BaseEntity
{
    public Guid UserId { get;  set; }
    public Guid RoleId { get;  set; }
}
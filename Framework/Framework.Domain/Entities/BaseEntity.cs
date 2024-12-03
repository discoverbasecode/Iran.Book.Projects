namespace Framework.Domain.Entities;

public class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; } = false;
    public DateTime? DeleteDate { get; set; }
    public string? DeleteBy { get; set; }

    public string? IpAddress { get; set; }
}
namespace Framework.Domain.Entities;

public interface IBaseEntity
{
    public Guid Id { get; set; }

    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }

    public bool IsActive { get; set; }
    
    public bool IsDelete { get; set; }
    public DateTime? DeleteDate { get; set; }
    public string? DeleteBy { get; set; }

    public string? IpAddress { get; set; }

}
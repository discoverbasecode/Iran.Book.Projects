namespace Framework.Domain.Entities;

public interface IBaseEntity
{
    public Guid Id { get; set; }
    public string? CreatedByIp { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }

    public string? UpdatedByIp { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
    
    public bool IsDeleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedByIp { get; set; }

    public bool IsActive { get; set; }
    public int Version { get; set; }
    public string? Metadata { get; set; }
    public bool IsLocked { get; set; }
    public List<string>? Tags { get; set; }
    public string? ChangeLog { get; set; }


    public void UpdateTimestamp();
    public void SoftDelete(Guid? deletedBy = null);
    public void Restore();
    public void UpdateAudit(Guid? updatedBy);
}
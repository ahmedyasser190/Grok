using ResourceManagement.Domain.Shared;

namespace ResourceManagement.Domain.Entities;

public abstract class BaseEntity<TKey> : ICreationAudit, IModificationAudit where TKey : struct
{
    public TKey Id { get; set; }
    public bool? IsActive { get; set; } = true;

    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }

    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
}

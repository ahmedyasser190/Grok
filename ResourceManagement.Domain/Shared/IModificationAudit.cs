namespace ResourceManagement.Domain.Shared;

public interface IModificationAudit
{
    string? ModifiedBy { get; set; }
    DateTime? ModifiedAt { get; set; }
}

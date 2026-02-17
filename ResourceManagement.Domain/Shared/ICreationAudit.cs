namespace ResourceManagement.Domain.Shared;

public interface ICreationAudit
{
    string? CreatedBy { get; set; }
    DateTime CreatedAt { get; set; }
}

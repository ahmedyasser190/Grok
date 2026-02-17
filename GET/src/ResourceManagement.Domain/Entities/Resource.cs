using ResourceManagement.Domain.Enums;

namespace ResourceManagement.Domain.Entities;

public class Resource : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public string? ResourceCode { get; set; }
    public string? FullName { get; set; } = default!;
    public string? Phone { get; set; }

    public DateOnly? HireDate { get; set; }
    
}

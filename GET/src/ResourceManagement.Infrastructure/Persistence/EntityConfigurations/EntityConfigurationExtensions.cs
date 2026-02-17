using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManagement.Domain.Shared;

namespace ResourceManagement.Infrastructure.Persistence.EntityConfigurations;

public static class EntityConfigurationExtensions
{
    public static EntityTypeBuilder<T> HasCreation<T>(this EntityTypeBuilder<T> builder) where T : class, ICreationAudit
    {
        builder.Property(e => e.CreatedBy)
            .HasMaxLength(DomainConstants.MaxAuditUserLength);

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        return builder;
    }

    public static EntityTypeBuilder<T> HasModification<T>(this EntityTypeBuilder<T> builder) where T : class, IModificationAudit
    {
        builder.Property(e => e.ModifiedBy)
            .HasMaxLength(DomainConstants.MaxAuditUserLength);

        builder.Property(e => e.ModifiedAt);

        return builder;
    }
}

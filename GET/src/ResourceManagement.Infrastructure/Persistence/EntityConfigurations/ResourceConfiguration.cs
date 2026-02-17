using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManagement.Domain.Entities;
using ResourceManagement.Domain.Shared;

namespace ResourceManagement.Infrastructure.Persistence.EntityConfigurations;

public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasCreation();
        builder.HasModification();

        builder.Property(r => r.IsActive)
            .HasDefaultValue(true);

        builder.Property(r => r.ResourceCode);

        builder.Property(r => r.FullName)
            .HasMaxLength(DomainConstants.MaxNameLength);

        builder.Property(r => r.Phone);
        builder.Property(r => r.HireDate);
    }
}

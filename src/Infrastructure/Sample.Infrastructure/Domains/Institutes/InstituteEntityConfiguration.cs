using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Constants;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes
{
    internal class InstituteEntityConfiguration : IEntityTypeConfiguration<Institute>
    {
        public void Configure(EntityTypeBuilder<Institute> builder)
        {
            builder.HasIndex(x => x.Id).IsUnique();

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");

            builder.Property<bool>("IsDeleted").HasDefaultValue(false);

            builder.Property<DateTimeOffset?>("DeletedAt").IsRequired(false);

            builder.HasQueryFilter(p => EF.Property<bool>(p, "IsDeleted") == false);

			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Institute.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.Code, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Institute.Code))
					.HasMaxLength(ConstantValues.MaxStringCodeLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.WebsiteUrl, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Institute.WebsiteUrl))
					.HasMaxLength(ConstantValues.MaxStringWebsiteUrlLength)
					.IsRequired(true);
			});

			builder.OwnsOne(typeof(Address), "Address");

			builder.ToTable(nameof(Institute));
        }
    }
}

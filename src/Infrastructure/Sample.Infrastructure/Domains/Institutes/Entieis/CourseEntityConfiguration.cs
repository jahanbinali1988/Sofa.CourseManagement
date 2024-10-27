using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Institutes.Constants;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
    internal class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasIndex(x => x.Id).IsUnique();

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");

            builder.Property<bool>("IsDeleted").HasDefaultValue(false);

            builder.Property<DateTimeOffset?>("DeletedAt").IsRequired(false);

            builder.HasQueryFilter(p => EF.Property<bool>(p, "IsDeleted") == false);

            builder.HasOne<Field>(c => c.Field).WithMany(x=> x.Courses).HasForeignKey(x=> x.FieldId.Value);

			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Course.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.AgeRange, m =>
			{
				m.Property(x => x.Title)
					.HasColumnName(nameof(Course.AgeRange) + "Title")
					.HasMaxLength(ConstantValues.MaxStringEnumLength)
					.IsRequired(true);

				m.Property(x => x.Value)
					.HasColumnName(nameof(Course.AgeRange))
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.FieldId, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Course.FieldId))
					.HasMaxLength(ConstantValues.MaxStringCorelationIdLength)
					.IsRequired(true);
			});

			builder.ToTable(nameof(Course));
        }
    }
}

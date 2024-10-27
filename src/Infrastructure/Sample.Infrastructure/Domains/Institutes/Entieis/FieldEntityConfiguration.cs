using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Constants;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
    internal class FieldEntityConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("SYSDATETIMEOFFSET()");

            builder.Property<bool>("IsDeleted")
                .HasDefaultValue(false);

            builder.Property<DateTimeOffset?>("DeletedAt")
                .IsRequired(false);

			builder.HasQueryFilter(p => EF.Property<bool>(p, "IsDeleted") == false);

			builder.HasOne<Institute>(c => c.Institute).WithMany(x=> x.Fields).HasForeignKey(x=> x.InstituteId.Value);
            
			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Field.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.InstituteId, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Field.InstituteId))
					.HasMaxLength(ConstantValues.MaxStringCorelationIdLength)
					.IsRequired(true);
			});

            builder.ToTable(nameof(Field));
        }
    }
}

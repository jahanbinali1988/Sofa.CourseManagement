using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared.Constants;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class FieldEntityConfiguration : BaseEntityTypeConfiguration<Field>
	{
		public override void Configure(EntityTypeBuilder<Field> builder)
		{

			builder.HasIndex(x => x.Id)
				.IsUnique();

			builder.HasMany<Course>(c => c.Courses).WithOne().HasForeignKey(x => x.FieldId).IsRequired().OnDelete(DeleteBehavior.Cascade);

			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Field.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			});
			base.Configure(builder);
		}
	}
}

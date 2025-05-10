using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class FieldEntityConfiguration : BaseEntityTypeConfiguration<Field>
	{
		public override void Configure(EntityTypeBuilder<Field> builder)
		{

			builder.HasIndex(x => x.Id)
				.IsUnique();

			builder.HasMany<Course>(c => c.Courses).WithOne(c=> c.Field).HasForeignKey(x => x.FieldId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.Metadata.FindNavigation(nameof(Field.Courses))?.SetPropertyAccessMode(PropertyAccessMode.Field);

			builder.HasMany<FieldQuestion>(c => c.Questions).WithOne(c=> c.Field).HasForeignKey(x => x.FieldId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.Metadata.FindNavigation(nameof(Field.Questions))?.SetPropertyAccessMode(PropertyAccessMode.Field);

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

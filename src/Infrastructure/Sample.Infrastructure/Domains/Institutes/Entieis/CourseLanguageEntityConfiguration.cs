using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class CourseLanguageEntityConfiguration : BaseEntityTypeConfiguration<CourseLanguage>
	{
		public override void Configure(EntityTypeBuilder<CourseLanguage> builder)
		{
			base.Configure(builder);
			builder.HasIndex(x => x.Id).IsUnique();

			builder.OwnsOne(p => p.Language, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(CourseLanguage.Language))
					.HasMaxLength(ConstantValues.MaxStringEnumLength)
					.IsRequired(true);
			});
		}
	}
}

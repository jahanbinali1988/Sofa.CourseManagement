using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Institutes.Entities.Sessions;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class CourseEntityConfiguration : BaseEntityTypeConfiguration<Course>
	{
		public override void Configure(EntityTypeBuilder<Course> builder)
		{
			base.Configure(builder);
			builder.HasIndex(x => x.Id).IsUnique();

			builder.HasMany<Session>(c => c.Sessions).WithOne().HasForeignKey(x => x.CourseId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.HasMany<CoursePlacement>(c => c.Placements).WithOne().HasForeignKey(x => x.CourseId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.HasMany<CourseUser>(c => c.CourseUsers).WithOne().HasForeignKey(x => x.CourseId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.HasMany<CourseLanguage>(c => c.CourseLanguages).WithOne().HasForeignKey(x => x.CourseId).IsRequired().OnDelete(DeleteBehavior.Cascade);

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
		}
	}
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Institutes.Entities.Sessions;
using Sofa.CourseManagement.Domain.Users;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class CourseEntityConfiguration : BaseEntityTypeConfiguration<Course>
	{
		public override void Configure(EntityTypeBuilder<Course> builder)
		{
			base.Configure(builder);
			builder.HasIndex(x => x.Id).IsUnique();

			builder.HasMany<Session>(c => c.Sessions).WithOne(c=> c.Course).HasForeignKey(x => x.CourseId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.Metadata.FindNavigation(nameof(Course.Sessions))?.SetPropertyAccessMode(PropertyAccessMode.Field);

			builder.HasMany<CoursePlacement>(c => c.Placements).WithOne(c=> c.Course).HasForeignKey(x => x.CourseId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.Metadata.FindNavigation(nameof(Course.Placements))?.SetPropertyAccessMode(PropertyAccessMode.Field);

			builder.HasMany<CourseUser>(c => c.CourseUsers).WithOne(c=> c.Course).HasForeignKey(x => x.CourseId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.Metadata.FindNavigation(nameof(Course.CourseUsers))?.SetPropertyAccessMode(PropertyAccessMode.Field);

			builder.HasMany<CourseLanguage>(c => c.CourseLanguages).WithOne(c=> c.Course).HasForeignKey(x => x.CourseId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.Metadata.FindNavigation(nameof(Course.CourseLanguages))?.SetPropertyAccessMode(PropertyAccessMode.Field);

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

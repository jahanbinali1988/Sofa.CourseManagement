using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class CourseUserEntityConfiguration : BaseEntityTypeConfiguration<CourseUser>
	{
		public override void Configure(EntityTypeBuilder<CourseUser> builder)
		{
			base.Configure(builder);
			builder.HasIndex(x => x.Id).IsUnique();
		}
	}
}

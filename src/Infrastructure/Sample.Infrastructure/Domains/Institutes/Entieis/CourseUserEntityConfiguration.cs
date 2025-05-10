using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Users;
using System;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class CourseUserEntityConfiguration : BaseEntityTypeConfiguration<CourseUser>
	{
		public override void Configure(EntityTypeBuilder<CourseUser> builder)
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
			

			builder.HasOne(cu => cu.User)
				.WithMany(u => u.CourseUsers)
				.HasForeignKey(cu => cu.UserId)
				.IsRequired()
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(cu => cu.Course)
				.WithMany(c => c.CourseUsers)
				.HasForeignKey(cu => cu.CourseId)
				.IsRequired()
				.OnDelete(DeleteBehavior.NoAction);

			base.Configure(builder);
		}
	}
}

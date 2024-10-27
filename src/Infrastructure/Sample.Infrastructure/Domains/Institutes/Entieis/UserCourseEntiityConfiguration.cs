using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.Institutes.Constants;
using Sofa.CourseManagement.Domain.Institutes.Entities;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class UserCourseEntiityConfiguration : IEntityTypeConfiguration<UserCourse>
	{
		public void Configure(EntityTypeBuilder<UserCourse> builder)
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

			builder.HasOne<User>(c => c.User).WithMany(x => x.UserCourses).HasForeignKey(x => x.UserId.Value);

			builder.HasOne<Course>(c => c.Course).WithMany(x => x.UserCourses).HasForeignKey(x => x.CourseId.Value);

			builder.OwnsOne(p => p.UserId, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(UserCourse.UserId))
					.HasMaxLength(ConstantValues.MaxStringCorelationIdLength)
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.CourseId, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(UserCourse.CourseId))
					.HasMaxLength(ConstantValues.MaxStringCorelationIdLength)
					.IsRequired(true);
			});

			builder.ToTable(nameof(UserCourse));
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.CourseManagement.Domain.LessonPlans.Constants;
using Sofa.CourseManagement.Domain.LessonPlans.Entities;
using System;

namespace Sofa.CourseManagement.Infrastructure.Domains.LessonPlans.Entities
{
	public class SoundPostEntityConfiguration : IEntityTypeConfiguration<SoundPost>
	{
		public void Configure(EntityTypeBuilder<SoundPost> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasMaxLength(ConstantValues.MaxStringIdLength).ValueGeneratedNever();
			builder.HasIndex(x => x.Id).IsUnique();
			builder.HasIndex(x => x.LessonPlanId.Value);
			
			builder.OwnsOne(p => p.ContentType, m =>
			{
				m.Property(x => x.Title)
					.HasColumnName(nameof(SoundPost.ContentType) + "Title")
					.HasMaxLength(ConstantValues.MaxStringEnumLength)
					.IsRequired(true);

				m.Property(x => x.Value)
					.HasColumnName(nameof(SoundPost.ContentType))
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.Content, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(SoundPost.Content))
					.HasMaxLength(ConstantValues.MaxStringContentLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(SoundPost.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.LessonPlanId, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(SoundPost.LessonPlanId))
					.HasMaxLength(ConstantValues.MaxStringIdLength)
					.IsRequired(true);
			});
			builder.Property(p => p.Order).IsRequired(true);

			builder.Property(x => x.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
			builder.Property<bool>("IsDeleted").HasDefaultValue(false);
			builder.Property<DateTimeOffset?>("DeletedAt").IsRequired(false);
			builder.HasQueryFilter(p => EF.Property<bool>(p, "IsDeleted") == false);
			builder.Ignore(b => b.DomainEvents);

			builder.ToTable(nameof(SoundPost));
		}
	}
}

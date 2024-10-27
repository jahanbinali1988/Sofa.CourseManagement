using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.LessonPlans.Entities;
using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.Domain.LessonPlans.Constants;

namespace Sofa.CourseManagement.Infrastructure.Domains.LessonPlans.Entities
{
    internal class PostBaseEntityConfiguration : IEntityTypeConfiguration<PostBase>
    {
        public void Configure(EntityTypeBuilder<PostBase> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasMaxLength(ConstantValues.MaxStringIdLength).ValueGeneratedNever();
			builder.HasIndex(x => x.Id).IsUnique();
			builder.HasIndex(x => x.LessonPlanId.Value);

			builder.HasOne<LessonPlan>()
                .WithMany(parent => parent.Posts)
                .HasForeignKey(k=> k.LessonPlanId);

			builder.OwnsOne(p => p.ContentType, m =>
			{
				m.Property(x => x.Title)
					.HasColumnName(nameof(PostBase.ContentType) + "Title")
					.HasMaxLength(ConstantValues.MaxStringEnumLength)
					.IsRequired(true);

				m.Property(x => x.Value)
					.HasColumnName(nameof(PostBase.ContentType))
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.Content, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(PostBase.Content))
					.HasMaxLength(ConstantValues.MaxStringContentLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(PostBase.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.LessonPlanId, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(PostBase.LessonPlanId))
					.HasMaxLength(ConstantValues.MaxStringIdLength)
					.IsRequired(true);
			});
			builder.Property(p => p.Order).IsRequired(true);

			builder.Property(x => x.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
			builder.Property<bool>("IsDeleted").HasDefaultValue(false);
			builder.Property<DateTimeOffset?>("DeletedAt").IsRequired(false);
			builder.HasQueryFilter(p => EF.Property<bool>(p, "IsDeleted") == false);
			builder.Ignore(b => b.DomainEvents);

			builder.ToTable(nameof(PostBase));
        }
    }
}

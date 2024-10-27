using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.Domain.LessonPlans.Constants;

namespace Sofa.CourseManagement.Infrastructure.Domains.LessonPlans
{
    internal class LessonPlanEntityConfigration : IEntityTypeConfiguration<LessonPlan>
    {
        public void Configure(EntityTypeBuilder<LessonPlan> builder)
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

            builder.HasOne(a => a.Session).WithOne(b => b.LessonPlan).HasForeignKey<Session>(c => c.LessonPlanId.Value);

            builder.HasMany(c => c.Posts).WithOne(x=> x.LessonPlan).HasForeignKey(x=> x.LessonPlanId.Value);

			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(LessonPlan.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			}); 

			builder.OwnsOne(p => p.Level, m =>
			{
				m.Property(x => x.Title)
					.HasColumnName(nameof(LessonPlan.Level) + "Title")
					.HasMaxLength(ConstantValues.MaxStringEnumLength)
					.IsRequired(true);

				m.Property(x => x.Value)
					.HasColumnName(nameof(LessonPlan.Level))
					.IsRequired(true);
			});

			builder.ToTable(nameof(LessonPlan));
        }
    }
}

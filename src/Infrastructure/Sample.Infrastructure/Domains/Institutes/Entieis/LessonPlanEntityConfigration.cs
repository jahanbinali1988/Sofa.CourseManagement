using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.CourseManagement.Domain.Institutes.Entities.LessonPlans;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{

	internal class LessonPlanEntityConfigration : BaseEntityTypeConfiguration<LessonPlan>
    {
		public override void Configure(EntityTypeBuilder<LessonPlan> builder)
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

            builder.HasMany(c => c.Posts).WithOne().HasForeignKey(x => x.LessonPlanId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<CourseLanguage>(c => c.CourseLanguage).WithMany().OnDelete(DeleteBehavior.NoAction); ;

			builder.OwnsOne(p => p.Title, m =>
            {
                m.Property(x => x.Value)
                    .HasColumnName(nameof(LessonPlan.Title))
                    .HasMaxLength(ConstantValues.MaxStringTitleLength)
                    .IsRequired(true);
            });

			base.Configure(builder);
		}
    }
}

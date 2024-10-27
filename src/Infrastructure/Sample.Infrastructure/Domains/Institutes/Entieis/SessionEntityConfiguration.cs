using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.Domain.Institutes.Constants;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
    internal class SessionEntityConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
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

			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Session.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.TermId, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Session.TermId))
					.HasMaxLength(ConstantValues.MaxStringCorelationIdLength)
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.LessonPlanId, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Session.LessonPlanId))
					.HasMaxLength(ConstantValues.MaxStringCorelationIdLength)
					.IsRequired(true);
			});

            builder.HasOne<Term>(c => c.Term).WithMany(x=> x.Sessions).HasForeignKey(x=> x.TermId.Value);

            builder.HasOne(a => a.LessonPlan).WithOne(b => b.Session).HasForeignKey<LessonPlan>(c => c.SessionId.Value);

            builder.ToTable(nameof(Session));
        }
    }
}

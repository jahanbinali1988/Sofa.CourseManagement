using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.CourseManagement.Domain.Institutes.Entities.Sessions;
using Sofa.CourseManagement.Domain.Institutes.Entities.LessonPlans;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class SessionEntityConfiguration : BaseEntityTypeConfiguration<Session>
	{
		public override void Configure(EntityTypeBuilder<Session> builder)
		{
			builder.HasIndex(x => x.Id)
				.IsUnique();

			builder.HasMany<LessonPlan>(c => c.LessonPlans).WithOne(c=> c.Session).HasForeignKey(x => x.SessionId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.Metadata.FindNavigation(nameof(Session.LessonPlans))?.SetPropertyAccessMode(PropertyAccessMode.Field);

			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Session.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.OccurredDate, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Session.OccurredDate))
					.HasMaxLength(ConstantValues.MaxStringDateTimeLength)
					.IsRequired(true);
			});

			base.Configure(builder);
		}
	}
}

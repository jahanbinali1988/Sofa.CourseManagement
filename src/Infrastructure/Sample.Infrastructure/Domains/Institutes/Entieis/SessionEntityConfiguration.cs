using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Institutes.Constants;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class SessionEntityConfiguration : BaseEntityTypeConfiguration<Session>
	{
		public override void Configure(EntityTypeBuilder<Session> builder)
		{

			builder.HasIndex(x => x.Id)
				.IsUnique();

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

			builder.ToTable(nameof(Session));
			base.Configure(builder);
		}
	}
}

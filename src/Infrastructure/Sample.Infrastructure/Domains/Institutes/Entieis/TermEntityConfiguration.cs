using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared.Constants;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class TermEntityConfiguration : BaseEntityTypeConfiguration<Term>
	{
		public override void Configure(EntityTypeBuilder<Term> builder)
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

			builder.HasMany<Session>(c => c.Sessions).WithOne().HasForeignKey(x => x.TermId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.HasMany<UserTerm>(c => c.UserTerms).WithOne().HasForeignKey(x => x.TermId).IsRequired().OnDelete(DeleteBehavior.NoAction);

			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Term.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			});

			base.Configure(builder);
		}
	}
}

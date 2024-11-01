﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.Institutes.Entities;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class UserTermEntiityConfiguration : BaseEntityTypeConfiguration<UserTerm>
	{
		public override void Configure(EntityTypeBuilder<UserTerm> builder)
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

			builder.HasOne<User>(c => c.User).WithMany().HasForeignKey(x => x.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

			builder.HasOne<Term>(c => c.Term).WithMany().HasForeignKey(x => x.TermId).IsRequired().OnDelete(DeleteBehavior.Cascade);

			builder.ToTable(nameof(UserTerm));
			base.Configure(builder);
		}
	}
}

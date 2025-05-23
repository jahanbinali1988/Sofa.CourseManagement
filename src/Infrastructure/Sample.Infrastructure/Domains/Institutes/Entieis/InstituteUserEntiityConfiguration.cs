﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.Institutes.Entities.Users;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class InstituteUserEntiityConfiguration : BaseEntityTypeConfiguration<InstituteUser>
	{
		public override void Configure(EntityTypeBuilder<InstituteUser> builder)
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

			base.Configure(builder);
		}
	}
}

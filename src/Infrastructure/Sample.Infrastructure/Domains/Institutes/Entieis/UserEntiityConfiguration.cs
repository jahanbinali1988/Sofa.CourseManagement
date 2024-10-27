using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Constants;
using Sofa.CourseManagement.Domain.Institutes.Entities;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class UserEntiityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
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

			builder.HasOne<Institute>(c => c.Institute).WithMany(x => x.Users).HasForeignKey(x => x.InstituteId.Value);

			builder.Property(x => x.PasswordHash).HasMaxLength(64);

			builder.OwnsOne(p => p.UserName, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(User.UserName))
					.HasMaxLength(ConstantValues.MaxStringUserNameLength)
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.FirstName, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(User.FirstName))
					.HasMaxLength(ConstantValues.MaxStringNameLength)
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.LastName, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(User.LastName))
					.HasMaxLength(ConstantValues.MaxStringNameLength)
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.PhoneNumber, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(User.PhoneNumber))
					.HasMaxLength(ConstantValues.MaxStringPhoneNumberLength)
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.Email, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(User.Email))
					.HasMaxLength(ConstantValues.MaxStringEmailLength)
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.InstituteId, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(User.InstituteId))
					.HasMaxLength(ConstantValues.MaxStringCorelationIdLength)
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.Level, m =>
			{
				m.Property(x => x.Title)
					.HasColumnName(nameof(User.Level) + "Title")
					.HasMaxLength(ConstantValues.MaxStringEnumLength)
					.IsRequired(true);

				m.Property(x => x.Value)
					.HasColumnName(nameof(User.Level))
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.Role, m =>
			{
				m.Property(x => x.Title)
					.HasColumnName(nameof(User.Role) + "Title")
					.HasMaxLength(ConstantValues.MaxStringEnumLength)
					.IsRequired(true);

				m.Property(x => x.Value)
					.HasColumnName(nameof(User.Role))
					.IsRequired(true);
			});

			builder.ToTable(nameof(User));
        }
    }
}

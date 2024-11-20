using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared.Constants;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes
{
	internal class InstituteEntityConfiguration : BaseEntityTypeConfiguration<Institute>
    {
        public override void Configure(EntityTypeBuilder<Institute> builder)
        {
            builder.HasIndex(x => x.Id).IsUnique();

			builder.HasMany<Field>(c=> c.Fields).WithOne().HasForeignKey(x => x.InstituteId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.Metadata.FindNavigation(nameof(Institute.Fields))?.SetPropertyAccessMode(PropertyAccessMode.Field);
			
			builder.HasMany<InstituteUser>(c => c.InstituteUsers).WithOne(c=> c.Institute).HasForeignKey(x => x.InstituteId).IsRequired().OnDelete(DeleteBehavior.NoAction);
			builder.Metadata.FindNavigation(nameof(Institute.InstituteUsers))?.SetPropertyAccessMode(PropertyAccessMode.Field);
			
			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Institute.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.Code, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Institute.Code))
					.HasMaxLength(ConstantValues.MaxStringCodeLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.WebsiteUrl, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Institute.WebsiteUrl))
					.HasMaxLength(ConstantValues.MaxStringWebsiteUrlLength)
					.IsRequired(true);
			});


			builder.OwnsOne(p => p.Address, m =>
			{
				m.Property(x => x.Country)
					.HasColumnName("Address_"+nameof(Address.Country))
					.HasMaxLength(ConstantValues.MaxStringAddressLength)
					.IsRequired(true);
				m.Property(x => x.State)
					.HasColumnName("Address_" + nameof(Address.State))
					.HasMaxLength(ConstantValues.MaxStringAddressLength)
					.IsRequired(true);
				m.Property(x => x.City)
					.HasColumnName("Address_" + nameof(Address.City))
					.HasMaxLength(ConstantValues.MaxStringAddressLength)
					.IsRequired(true);
				m.Property(x => x.Street)
					.HasColumnName("Address_" + nameof(Address.Street))
					.HasMaxLength(ConstantValues.MaxStringAddressLength)
					.IsRequired(true);
				m.Property(x => x.ZipCode)
					.HasColumnName("Address_" + nameof(Address.ZipCode))
					.HasMaxLength(ConstantValues.MaxStringAddressLength)
					.IsRequired(true);
			});
        }
    }
}

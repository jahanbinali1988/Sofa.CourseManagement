using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using System.Reflection.Emit;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class CoursePlacementEntityConfiguration : BaseEntityTypeConfiguration<CoursePlacement>
	{
		public override void Configure(EntityTypeBuilder<CoursePlacement> builder)
		{
			base.Configure(builder);
			builder.HasIndex(x => x.Id).IsUnique();

			builder.HasMany<CoursePlacementQuestion>(c => c.Questions).WithOne(c=> c.CoursePlacement).HasForeignKey(x => x.PlacementId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.Metadata.FindNavigation(nameof(CoursePlacement.Questions))!.SetPropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Course.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			});
		}
	}
}

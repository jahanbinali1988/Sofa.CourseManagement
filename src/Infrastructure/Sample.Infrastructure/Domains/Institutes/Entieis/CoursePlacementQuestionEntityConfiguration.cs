using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Institutes.Entities;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class CoursePlacementQuestionEntityConfiguration : BaseEntityTypeConfiguration<CoursePlacementQuestion>
	{
		public override void Configure(EntityTypeBuilder<CoursePlacementQuestion> builder)
		{
			base.Configure(builder);
			builder.HasIndex(x => x.Id).IsUnique();

			builder.HasOne<FieldQuestion>(c => c.Question).WithMany().OnDelete(DeleteBehavior.NoAction);

			builder.OwnsOne(p => p.Order, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(CoursePlacementQuestion.Order))
					.IsRequired(true);
			});
		}
	}
}

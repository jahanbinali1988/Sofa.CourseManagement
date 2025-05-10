using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared.Constants;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class FieldQuestionChoiceEntityConfiguration : BaseEntityTypeConfiguration<FieldQuestionChoice>
	{
		public override void Configure(EntityTypeBuilder<FieldQuestionChoice> builder)
		{

			builder.HasIndex(x => x.Id)
				.IsUnique();

			builder.OwnsOne(p => p.Content, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(FieldQuestion.Content))
					.HasMaxLength(ConstantValues.MaxStringContentLength)
					.IsRequired(true);
			});
			builder.Property(c => c.IsAnswer);

			base.Configure(builder);
		}
	}
}

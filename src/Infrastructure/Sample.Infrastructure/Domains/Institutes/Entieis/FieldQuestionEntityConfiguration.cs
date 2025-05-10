using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared.Constants;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class FieldQuestionEntityConfiguration : BaseEntityTypeConfiguration<FieldQuestion>
	{
		public override void Configure(EntityTypeBuilder<FieldQuestion> builder)
		{

			builder.HasIndex(x => x.Id)
				.IsUnique();

			builder.HasMany<FieldQuestionChoice>(c => c.QuestionChoices).WithOne(c=> c.FieldQuestion).HasForeignKey(x => x.FieldQuestionId).IsRequired().OnDelete(DeleteBehavior.Cascade);
			builder.Metadata.FindNavigation(nameof(FieldQuestion.QuestionChoices))?.SetPropertyAccessMode(PropertyAccessMode.Field);

			//builder.HasMany<CoursePlacementQuestion>(c => c.CoursePlacementQuestions).WithOne().HasForeignKey(x => x.QuestionId).IsRequired().OnDelete(DeleteBehavior.Cascade);

			builder.OwnsOne(p => p.Title, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(FieldQuestion.Title))
					.HasMaxLength(ConstantValues.MaxStringTitleLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.Content, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(FieldQuestion.Content))
					.HasMaxLength(ConstantValues.MaxStringContentLength)
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.Level, m =>
			{
				m.Property(x => x.Title)
					.HasColumnName(nameof(FieldQuestion.Level) + "Title")
					.HasMaxLength(ConstantValues.MaxStringEnumLength)
					.IsRequired(true);

				m.Property(x => x.Value)
					.HasColumnName(nameof(FieldQuestion.Level))
					.IsRequired(true);
			});
			builder.OwnsOne(p => p.Type, m =>
			{
				m.Property(x => x.Title)
					.HasColumnName(nameof(FieldQuestion.Type) + "Title")
					.HasMaxLength(ConstantValues.MaxStringEnumLength)
					.IsRequired(true);

				m.Property(x => x.Value)
					.HasColumnName(nameof(FieldQuestion.Type))
					.IsRequired(true);
			});

			base.Configure(builder);
		}
	}
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.CourseManagement.Domain.Institutes.Entities.Posts;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Microsoft.EntityFrameworkCore;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class PostQuestionEntityConfiguration : BaseEntityTypeConfiguration<PostQuestion>
	{
		public override void Configure(EntityTypeBuilder<PostQuestion> builder)
		{

			builder.HasKey(x => x.Id);
			builder.HasIndex(x => x.Id).IsUnique();

			builder.HasOne<FieldQuestion>(c => c.Question);

			builder.OwnsOne(p => p.Priority, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(PostQuestion.Priority))
					.IsRequired(true);
			});

			builder.Ignore(b => b.DomainEvents);

			base.Configure(builder);
		}
	}
}

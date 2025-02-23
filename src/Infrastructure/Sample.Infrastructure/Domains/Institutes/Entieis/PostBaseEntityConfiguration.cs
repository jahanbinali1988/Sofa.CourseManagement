using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.CourseManagement.Domain.Institutes.Entities.Posts;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	internal class PostBaseEntityConfiguration : BaseEntityTypeConfiguration<PostBase>
    {
		public override void Configure(EntityTypeBuilder<PostBase> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(ConstantValues.MaxStringIdLength).ValueGeneratedNever();
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasIndex(x => x.LessonPlanId);

            builder.HasOne<PostQuestion>(c => c.Question).WithOne().OnDelete(DeleteBehavior.NoAction);

            builder.OwnsOne(p => p.ContentType, m =>
            {
                m.Property(x => x.Title)
                    .HasColumnName(nameof(PostBase.ContentType) + "Title")
                    .HasMaxLength(ConstantValues.MaxStringEnumLength)
                    .IsRequired(true);

                m.Property(x => x.Value)
                    .HasColumnName(nameof(PostBase.ContentType))
                    .IsRequired(true);
            });
            builder.OwnsOne(p => p.Content, m =>
            {
                m.Property(x => x.Value)
                    .HasColumnName(nameof(PostBase.Content))
                    .HasMaxLength(ConstantValues.MaxStringContentLength)
                    .IsRequired(true);
            });
            builder.OwnsOne(p => p.Title, m =>
            {
                m.Property(x => x.Value)
                    .HasColumnName(nameof(PostBase.Title))
                    .HasMaxLength(ConstantValues.MaxStringTitleLength)
                    .IsRequired(true);
            });
			builder.OwnsOne(p => p.Order, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(PostBase.Order))
					.IsRequired(true);
			});

            builder.Ignore(b => b.DomainEvents);

			base.Configure(builder);
		}
    }
}

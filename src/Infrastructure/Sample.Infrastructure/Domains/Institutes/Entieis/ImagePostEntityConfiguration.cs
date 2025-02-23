using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.CourseManagement.Domain.Institutes.Entities.Posts;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	public class ImagePostEntityConfiguration : IEntityTypeConfiguration<ImagePost>
    {
        public void Configure(EntityTypeBuilder<ImagePost> builder)
        {
            //builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(ConstantValues.MaxStringIdLength).ValueGeneratedNever();
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasIndex(x => x.LessonPlanId);

            builder.OwnsOne(p => p.ContentType, m =>
            {
                m.Property(x => x.Title)
                    .HasColumnName(nameof(ImagePost.ContentType) + "Title")
                    .HasMaxLength(ConstantValues.MaxStringEnumLength)
                    .IsRequired(true);

                m.Property(x => x.Value)
                    .HasColumnName(nameof(ImagePost.ContentType))
                    .IsRequired(true);
            });
            builder.OwnsOne(p => p.Content, m =>
            {
                m.Property(x => x.Value)
                    .HasColumnName(nameof(ImagePost.Content))
                    .HasMaxLength(ConstantValues.MaxStringContentLength)
                    .IsRequired(true);
            });
            builder.OwnsOne(p => p.Title, m =>
            {
                m.Property(x => x.Value)
                    .HasColumnName(nameof(ImagePost.Title))
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

            builder.ToTable(nameof(ImagePost));
        }
    }
}

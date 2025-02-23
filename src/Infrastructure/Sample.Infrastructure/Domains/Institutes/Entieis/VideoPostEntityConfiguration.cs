using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Sofa.CourseManagement.Domain.Shared.Constants;
using Sofa.CourseManagement.Domain.Institutes.Entities.Posts;

namespace Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis
{
	public class VideoPostEntityConfiguration : IEntityTypeConfiguration<VideoPost>
    {
		public void Configure(EntityTypeBuilder<VideoPost> builder)
        {
            builder.Property(x => x.Id).HasMaxLength(ConstantValues.MaxStringIdLength).ValueGeneratedNever();
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasIndex(x => x.LessonPlanId);

            builder.OwnsOne(p => p.ContentType, m =>
            {
                m.Property(x => x.Title)
                    .HasColumnName(nameof(VideoPost.ContentType) + "Title")
                    .HasMaxLength(ConstantValues.MaxStringEnumLength)
                    .IsRequired(true);

                m.Property(x => x.Value)
                    .HasColumnName(nameof(VideoPost.ContentType))
                    .IsRequired(true);
            });

            builder.OwnsOne(p => p.Content, m =>
            {
                m.Property(x => x.Value)
                    .HasColumnName(nameof(VideoPost.Content))
                    .HasMaxLength(ConstantValues.MaxStringContentLength)
                    .IsRequired(true);
            });

            builder.OwnsOne(p => p.Title, m =>
            {
                m.Property(x => x.Value)
                    .HasColumnName(nameof(VideoPost.Title))
                    .HasMaxLength(ConstantValues.MaxStringTitleLength)
                    .IsRequired(true);
            });
			builder.OwnsOne(p => p.Order, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(PostBase.Order))
					.IsRequired(true);
			});

			builder.ToTable(nameof(VideoPost));
        }
    }
}

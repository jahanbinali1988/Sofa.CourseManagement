using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Sofa.SharedKernel.SeedWork;

namespace Sofa.CourseManagement.Infrastructure.Domains
{
    public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity<Guid>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			//builder.Property(i => i.RowVersion).IsConcurrencyToken();
			builder.Property(c=> c.Id).ValueGeneratedNever();
			builder.HasKey(c => c.Id);
			//builder.Ignore(c => c.DomainEvents);
			builder.HasQueryFilter(i => !i.IsDeleted);
			builder.ToTable(typeof(T).Name);
		}
    }
}

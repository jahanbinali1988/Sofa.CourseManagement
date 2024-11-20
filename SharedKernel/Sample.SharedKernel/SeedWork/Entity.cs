using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.SharedKernel.SeedWork
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    [Serializable]
    public abstract class Entity<TKey>
    {
        protected Entity()
        {
            CreatedAt = DateTimeOffset.Now;
        }

        public TKey Id { get; protected set; }
        public DateTimeOffset? ModifiedAt { get; protected set; }
		public bool IsDeleted { get; set; } = false;
		public DateTimeOffset? DeletedAt { get; protected set; }
		public DateTimeOffset CreatedAt { get; protected set; }
		//[Timestamp]
		//public byte[] RowVersion { get; set; }


		private List<IDomainEvent> _domainEvents = new();
		public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();


		protected static async Task CheckRule(IBusinessRule rule)
		{
			if (await rule.IsBroken())
			{
				throw new BusinessRuleValidationException(rule, rule.Properties, rule.ErrorType);
			}
		}

		protected void MarkAsDeleted()
		{
			DeletedAt = DateTimeOffset.Now;
			IsDeleted = true;
		}

		protected void MarkAsUpdated()
		{
			ModifiedAt = DateTimeOffset.Now;
		}

		protected void AssignId(TKey id)
		{
			this.Id = id;
		}


		/// <summary>
		/// Add domain event.
		/// </summary>
		/// <param name="domainEvent"></param>
		protected void AddDomainEvent(IDomainEvent domainEvent)
		{
			_domainEvents ??= new List<IDomainEvent>();
			_domainEvents.Add(domainEvent);
		}

		/// <summary>
		/// Clear domain events.
		/// </summary>
		public void ClearDomainEvents()
		{
			_domainEvents?.Clear();
		}

	}

	public abstract class Entity : Entity<Guid>
    {

    }
}

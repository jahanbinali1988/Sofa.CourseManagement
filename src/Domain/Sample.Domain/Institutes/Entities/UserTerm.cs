using Sofa.CourseManagement.Domain.Contract.Institutes.Events.UserTerms;
using Sofa.CourseManagement.Domain.Users;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
	public class UserTerm : Entity<Guid>
	{
        private UserTerm(Guid id, Guid userId, Guid termId) : this()
        {
            base.Id = id;
            AssignTermId(termId);
            AssignUserId(userId);
        }
        private UserTerm() : base()
        {
            
        }
        
        public Guid TermId { get; private set; }
		public Guid UserId { get; private set; }

		public Term Term { get; private set; }
		public User User { get; private set; }

		private void AssignUserId(Guid userId) { UserId = userId; }
		private void AssignTermId(Guid termId) { TermId = termId; }

        public static UserTerm CreateInstance(Guid id, Guid userId, Guid termId)
        {
            var userTerm = new UserTerm(id, userId, termId);

            userTerm.AddDomainEvent(new AddUserTermDomainEvent(userTerm.Id, userTerm.UserId, userTerm.TermId));

            return userTerm;
        }
        public void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteUserTermDomainEvent(Id));
        }
	}
}

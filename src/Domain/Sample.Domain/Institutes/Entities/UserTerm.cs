using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
	public class UserTerm : Entity<Guid>
	{
        private UserTerm(Guid id, Guid userId, Guid termId)
        {
            base.Id = id;
            AssignCourseId(termId);
            AssignUserId(userId);
        }
        private UserTerm()
        {
            
        }
        public Guid TermId { get; private set; }
		public Guid UserId { get; private set; }

		public void AssignUserId(Guid userId) { UserId = userId; }
		public void AssignCourseId(Guid termId) { TermId = termId; }

        public static UserTerm CreateInstance(Guid id, Guid userId, Guid termId)
        {
            var userCourse = new UserTerm(id, userId, termId);

            return userCourse;
        }
	}
}

using Sofa.CourseManagement.Domain.Shared.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
	public class UserCourse : Entity<Guid>
	{
        private UserCourse(Guid id, Guid userId, Guid courseId)
        {
            base.Id = id;
            AssignCourseId(courseId);
            AssignUserId(userId);
        }
        private UserCourse()
        {
            
        }
        public CorelationId CourseId { get; private set; }
		public CorelationId UserId { get; private set; }

		public Course Course { get; private set; }
		public User User { get; private set; }


		public void AssignUserId(Guid userId) { UserId = userId; }
		public void AssignCourseId(Guid courseId) { CourseId = courseId; }

        public static UserCourse CreateInstance(Guid id, Guid userId, Guid courseId)
        {
            var userCourse = new UserCourse(id, userId, courseId);

            return userCourse;
        }
	}
}

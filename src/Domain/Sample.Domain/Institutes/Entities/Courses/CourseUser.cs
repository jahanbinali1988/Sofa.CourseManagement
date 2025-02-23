using Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseUser;
using Sofa.CourseManagement.Domain.Users;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.Courses
{
	public class CourseUser : Entity<Guid>
	{
		private CourseUser() : base()
		{
			
		}
		private CourseUser(Guid id, Guid courseId, Guid userId) : this()
		{
			AssignId(id);
			AssignCourse(courseId);
			AssignUser(userId);
		}

		public Guid CourseId { get; private set; }
		public Guid UserId { get; private set; }
		public User User { get; private set; }

		private void AssignCourse(Guid courseId) { this.CourseId = courseId; }
		private void AssignUser(Guid userId) { this.UserId = userId; }

		public static CourseUser CreateInstance(Guid id, Guid courseId, Guid userId) 
		{
			var instance = new CourseUser(id, courseId, userId);

			instance.AddDomainEvent(new AddCourseUserDomainEvent(id, courseId, userId));
			
			return instance;
		}
		public void Update(Guid courseId, Guid userId)
		{
			AssignCourse(courseId);
			AssignUser(userId);

			AddDomainEvent(new UpdateCourseUserDomainEvent(Id, courseId, userId));

			MarkAsUpdated();
		}
		public void Delete()
		{
			MarkAsDeleted();

			AddDomainEvent(new DeleteCourseUserDomainEvent(Id));
		}
	}
}

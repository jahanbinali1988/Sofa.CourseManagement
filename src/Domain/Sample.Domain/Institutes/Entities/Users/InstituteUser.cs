using Sofa.CourseManagement.Domain.Contract.Institutes.Events.InstituteUsers;
using Sofa.CourseManagement.Domain.Users;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.Users
{
	public class InstituteUser : Entity<Guid>
	{
		private InstituteUser(Guid id, Guid userId, Guid instituteId) : this()
		{
			Id = id;
			AssignInstituteId(instituteId);
			AssignUserId(userId);
		}
		private InstituteUser() : base()
		{
		}

		public Guid InstituteId { get; private set; }
		public Guid UserId { get; private set; }

		public Institute Institute { get; private set; }
		public User User { get; private set; }

		private void AssignUserId(Guid userId) { UserId = userId; }
		private void AssignInstituteId(Guid termId) { InstituteId = termId; }

		public static InstituteUser CreateInstance(Guid id, Guid userId, Guid instituteId)
		{
			var userInstitute = new InstituteUser(id, userId, instituteId);

			userInstitute.AddDomainEvent(new AddInstituteUserDomainEvent(userInstitute.Id, userInstitute.UserId, userInstitute.InstituteId));

			return userInstitute;
		}

		public void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteInstituteUserDomainEvent(Id));
		}
	}
}

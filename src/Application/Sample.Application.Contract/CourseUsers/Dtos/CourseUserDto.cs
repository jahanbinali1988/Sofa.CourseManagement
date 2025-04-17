using Sofa.CourseManagement.Application.Contract.Shared;
using System;

namespace Sofa.CourseManagement.Application.Contract.CourseUsers.Dtos
{
	public class CourseUserDto : EntityBaseDto
	{
		public Id UserId { get; set; }
		public string UserName { get; set; }
		public string UserPhoneNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Id CourseId { get; set; }
		public string CourseTitle { get; set; }
	}
}

using Sofa.CourseManagement.Application.Contract.Shared;
using System;

namespace Sofa.CourseManagement.Application.Contract.InstituteUsers.Dtos
{
	public class InstituteUserDto : EntityBaseDto
	{
		public Guid UserId { get; set; }
		public string UserName { get; set; }
		public string UserPhoneNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Guid InstituteId { get; set; }
		public string InstituteTitle { get; set; }
	}
}

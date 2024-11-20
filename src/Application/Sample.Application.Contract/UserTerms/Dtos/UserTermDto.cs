using Sofa.CourseManagement.Application.Contract.Shared;
using System;

namespace Sofa.CourseManagement.Application.Contract.UserTerms.Dtos
{
	public class UserTermDto : EntityBaseDto
	{
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string FirstName { get; set; }
		public string LastName { get; set; }
        public Guid TermId { get; set; }
        public string TermTitle { get; set; }
    }
}

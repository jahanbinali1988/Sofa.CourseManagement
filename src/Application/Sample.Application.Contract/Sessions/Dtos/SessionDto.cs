using Sofa.CourseManagement.Application.Contract.Shared;
using System;

namespace Sofa.CourseManagement.Application.Contract.Sessions.Dtos
{
	public class SessionDto : EntityBaseDto
	{
		public string Title { get; set; }
		public DateTimeOffset? OccurredDate { get; set; }
		public Id CourseId { get; set; }
		public string CourseTitle { get; set; }
		public Id FieldId { get; set; }
		public string FieldTitle { get; set; }
		public Id InstituteId { get; set; }
		public string InstituteTitle { get; set; }
	}
}

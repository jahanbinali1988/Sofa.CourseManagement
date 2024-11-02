using Sofa.CourseManagement.Application.Contract.Shared;
using System;

namespace Sofa.CourseManagement.Application.Contract.Sessions.Dtos
{
	public class SessionDto : EntityBaseDto
	{
		public string Title { get; set; }
		public Guid TermId { get; set; }
		public string TermTitle { get; set; }
		public Guid CourseId { get; set; }
		public string CourseTitle { get; set; }
		public Guid FieldId { get; set; }
		public string FieldTitle { get; set; }
		public Guid InstituteId { get; set; }
		public string InstituteTitle { get; set; }
		public DateTimeOffset? OccurredDate { get; set; }
	}
}

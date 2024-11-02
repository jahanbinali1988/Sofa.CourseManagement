using Sofa.CourseManagement.Application.Contract.Shared;
using System;

namespace Sofa.CourseManagement.Application.Contract.Terms.Dtos
{
	public class TermDto : EntityBaseDto
	{
        public string Title { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
		public string CourseTitle { get; set; }
		public string InstituteTitle { get; set; }
		public string FieldTitle { get; set; }
	}
}

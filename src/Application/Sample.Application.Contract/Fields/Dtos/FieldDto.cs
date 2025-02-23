using Sofa.CourseManagement.Application.Contract.Shared;
using System;

namespace Sofa.CourseManagement.Application.Contract.Fields.Dtos
{
	public class FieldDto : EntityBaseDto
	{
		public string Title { get; set; }
		public Id InstituteId { get; set; }
		public string InstituteTitle { get; set; }
	}
}
